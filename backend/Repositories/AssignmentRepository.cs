using backend.Data;
using backend.DTO;
using backend.Entities;
using backend.Enums;
using backend.Helpers;
using backend.Models.Assignments;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public interface IAssignmentRepository
    {
        public Task AddAssignment(CreateAssignmentModel assignment);
        public Task UpdateAssignment(UpdateAssignmentModel assignment, int assignmentId);
        public Task DeleteAssignment(int assignmentId);
        public Task<AssignmentDTO> GetAssignmentById(int assignmentId);
        public Task<ActionResult<List<HistoricalDTO>>> AssignmentHistoricals(int assetId);
        public Task<ActionResult<List<AssignmentDTO>>> GetAssignmentByLocation(int userId);
        public Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId);
        public Task CompleteAssignment(int assignmentId);
        public Task AcceptAssignment(int assignmentId);
        public Task RejectAssignment(int assignmentId);
    }
    public class AssignmentRepository : IAssignmentRepository
    {
        private MyDbContext _context;
        public AssignmentRepository(MyDbContext context)
        {
            _context = context;
        }
        private bool CheckAssignedDate(DateTime date)
        {
            if (DateTime.Now.Date <= date.Date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddAssignment(CreateAssignmentModel assignment)
        {
            try
            {
                var assignedByUser = _context.Users.FirstOrDefault(x => x.UserId == assignment.AssignedByUserId);
                var assignedToUser = _context.Users.FirstOrDefault(x => x.UserId == assignment.AssignedToUserId);
                var foundAsset = _context.Assets.FirstOrDefault(x => x.AssetId == assignment.AssetId);
                if (assignedByUser.Role != Role.Admin) throw new AppException("In valid user");
                if (foundAsset.AssetState != AssetState.Available) throw new AppException("You can assign this asset");
                if (!CheckAssignedDate(assignment.AssignedDate)) throw new AppException("Assigned date should not be in the past");
                if (assignedByUser != null
                    && assignedToUser != null
                    && foundAsset != null)
                {
                    //Change assigned asset sate
                    foundAsset.AssetState = AssetState.Assigned;
                    _context.Assets.Update(foundAsset);
                    await _context.SaveChangesAsync();
                    //Create new assignemtn
                    var createdAssignment = new Assignment
                    {
                        AssignedToUserId = assignment.AssignedToUserId,
                        AssignedToUserName = assignedToUser.UserName,
                        AssignedByUserId = assignment.AssignedByUserId,
                        AssignedByUserName = assignedByUser.UserName,
                        AssetId = assignment.AssetId,
                        AssetName = foundAsset.AssetName,
                        AssetCode = foundAsset.AssetCode,
                        Specification = foundAsset.Specification,
                        AssignedDate = assignment.AssignedDate,
                        Note = assignment.Note,
                        AssignmentState = AssignmentState.WaitingForAcceptance,
                        Location = assignedByUser.Location.ToString()
                    };
                    await _context.Assignments.AddAsync(createdAssignment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteAssignment(int assignmentId)
        {
            try
            {
                var foundAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentId == assignmentId);
                if (foundAssignment.AssignmentState != AssignmentState.WaitingForAcceptance) throw new AppException("you can not delete Reject or Accepted assignment");
                if (foundAssignment != null)
                {
                    _context.Assignments.Remove(foundAssignment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId)
        {
            try
            {
                var foundUser = _context.Users.Include(x => x.AssignedTo).FirstOrDefault(x => x.UserId == userId);
                if (foundUser == null) throw new AppException("User not found");
                if (foundUser != null)
                {
                    return foundUser.AssignedTo.Where(m => m.AssignmentState != AssignmentState.Rejected).Select(x => x.AssignmentEntityToDTO()).ToList();
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateAssignment(UpdateAssignmentModel assignment, int assignmentId)
        {
            try
            {
                var foundAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentId == assignmentId);
                var assignedToUser = _context.Users.FirstOrDefault(x => x.UserId == assignment.AssignedToUserId);
                var foundAsset = _context.Assets.FirstOrDefault(x => x.AssetId == assignment.AssetId);
                var oldAsset = _context.Assets.FirstOrDefault(x => x.AssetId == foundAssignment.AssetId);

                if (foundAssignment.AssignmentState != AssignmentState.WaitingForAcceptance) throw new AppException("You can not edit this assignment");
                if (!CheckAssignedDate(assignment.AssignedDate)) throw new AppException("Assigned date should not be in the past");
                if (foundAssignment != null
                    && assignedToUser != null
                    && foundAsset != null)
                {
                    if (assignment.AssetId != oldAsset.AssetId)
                    {
                        //Update state for old asset
                        oldAsset.AssetState = AssetState.Available;
                        _context.Assets.Update(oldAsset);
                        await _context.SaveChangesAsync();

                        //Update state for assigned asset
                        if (foundAsset.AssetState != AssetState.Available) throw new AppException("You can assign this asset");
                        foundAsset.AssetState = AssetState.Assigned;
                        _context.Assets.Update(foundAsset);
                        await _context.SaveChangesAsync();
                        foundAssignment.AssetId = assignment.AssetId;
                        foundAssignment.AssetName = foundAsset.AssetName;
                        foundAssignment.AssetCode = foundAsset.AssetCode;
                    }

                    //Update assignment
                    foundAssignment.AssignedToUserId = assignment.AssignedToUserId;
                    foundAssignment.AssignedToUserName = assignedToUser.UserName;
                    foundAssignment.Specification = foundAsset.Specification;
                    foundAssignment.AssignedDate = assignment.AssignedDate;
                    foundAssignment.Note = assignment.Note;

                    _context.Assignments.Update(foundAssignment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CompleteAssignment(int assignmentId)
        {
            try
            {
                var foundAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentId == assignmentId);
                if (foundAssignment.AssignmentState != AssignmentState.Accepted) throw new AppException("This assigned is waiting for accepted of have been returned");
                if (foundAssignment != null)
                {
                    //Upate asset state
                    var foundAsset = _context.Assets.FirstOrDefault(x => x.AssetId == foundAssignment.AssetId);
                    foundAsset.AssetState = AssetState.Available;
                    _context.Assets.Update(foundAsset);
                    await _context.SaveChangesAsync();
                    //Update assignment state
                    foundAssignment.AssignmentState = AssignmentState.Returned;
                    _context.Assignments.Update(foundAssignment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ActionResult<List<AssignmentDTO>>> GetAssignmentByLocation(int userId)
        {
            if (_context.Assignments != null)
            {
                try
                {
                    var foundUser = _context.Users.FirstOrDefault(x => x.UserId == userId);
                    if (foundUser != null)
                    {
                        var assignments = await _context.Assignments
                            .Where(x => x.Location == foundUser.Location.ToString())
                            .Select(m => m.AssignmentEntityToDTO())
                            .ToListAsync();
                        return new OkObjectResult(assignments);
                    }
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }

        public async Task<AssignmentDTO> GetAssignmentById(int assignmentId)
        {
            try
            {
                var foundAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentId == assignmentId);
                if (foundAssignment != null)
                {
                    return foundAssignment.AssignmentEntityToDTO();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AcceptAssignment(int assignmentId)
        {
            try
            {
                var foundAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentId == assignmentId);
                if (foundAssignment.AssignmentState != AssignmentState.WaitingForAcceptance) throw new AppException("Can not accept this assignment");
                if (foundAssignment != null)
                {
                    //update assignment state
                    foundAssignment.AssignmentState = AssignmentState.Accepted;
                    _context.Assignments.Update(foundAssignment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task RejectAssignment(int assignmentId)
        {
            try
            {
                var foundAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentId == assignmentId);
                var foundAsset = _context.Assets.FirstOrDefault(m => m.AssetId == foundAssignment.AssetId);
                if (foundAssignment.AssignmentState != AssignmentState.WaitingForAcceptance) throw new AppException("Can not reject this assignment");
                if (foundAssignment != null && foundAsset != null)
                {
                    //update asset state
                    foundAsset.AssetState = AssetState.Available;
                    _context.Assets.Update(foundAsset);
                    await _context.SaveChangesAsync();
                    //update assignment status
                    foundAssignment.AssignmentState = AssignmentState.Rejected;
                    _context.Assignments.Update(foundAssignment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ActionResult<List<HistoricalDTO>>> AssignmentHistoricals(int assetId)
        {
            if (_context.Assignments != null)
            {
                try
                {
                    var foundAsset = _context.Assets.FirstOrDefault(x => x.AssetId == assetId);
                    if (foundAsset != null)
                    {
                        var assignments = await _context.Assignments
                            .Where(x => x.AssetId == foundAsset.AssetId && x.AssignmentState == AssignmentState.Returned)
                            .Select(m => m.Historical())
                            .ToListAsync();
                        return new OkObjectResult(assignments);
                    }
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }
    }
}