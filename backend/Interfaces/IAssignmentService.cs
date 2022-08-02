using backend.DTO;
using backend.Entities;
using backend.Models.Assignments;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IAssignmentService
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
}