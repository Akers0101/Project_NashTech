using backend.DTO;
using backend.Entities;
using backend.Interfaces;
using backend.Models.Assignments;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public class AssignmentService : IAssignmentService
    {
        private IAssignmentRepository _repository;
        public AssignmentService(IAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task AcceptAssignment(int assignmentId)
        {
            await _repository.AcceptAssignment(assignmentId);
        }

        public async Task AddAssignment(CreateAssignmentModel assignment)
        {
            await _repository.AddAssignment(assignment);
        }

        public async Task<ActionResult<List<HistoricalDTO>>> AssignmentHistoricals(int assetId)
        {
            return await _repository.AssignmentHistoricals(assetId);
        }

        public async Task CompleteAssignment(int assignmetnId)
        {
            await _repository.CompleteAssignment(assignmetnId);
        }

        public async Task DeleteAssignment(int assignmentId)
        {
            await _repository.DeleteAssignment(assignmentId);
        }

        public async Task<AssignmentDTO> GetAssignmentById(int assignmentId)
        {
            return await _repository.GetAssignmentById(assignmentId);
        }

        public async Task<ActionResult<List<AssignmentDTO>>> GetAssignmentByLocation(int userId)
        {
            return await _repository.GetAssignmentByLocation(userId);
        }

        public async Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId)
        {
            return await _repository.GetAssignmentByUserId(userId);
        }

        public async Task RejectAssignment(int assignmentId)
        {
            await _repository.RejectAssignment(assignmentId);
        }

        public async Task UpdateAssignment(UpdateAssignmentModel assignment, int assignmentId)
        {
            await _repository.UpdateAssignment(assignment, assignmentId);
        }
    }
}