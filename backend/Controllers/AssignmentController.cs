using backend.DTO;
using backend.Models.Assignments;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Authorization;
using backend.Enums;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private IAssignmentService _service;
        public AssignmentController(IAssignmentService service)
        {
            _service = service;
        }

        [Authorize(Role.Admin)]
        [HttpPost("add")]
        public async Task AddAssignment([FromBody]CreateAssignmentModel assignment)
        {
            await _service.AddAssignment(assignment);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("delete")]
        public async Task DeleteAssignment(int assignmentId)
        {
            await _service.DeleteAssignment(assignmentId);
        }

        [Authorize(Role.Admin, Role.Staff)]
        [HttpGet("Historicals")]
        public async Task<ActionResult<List<HistoricalDTO>>> AssignmentHistoricals(int assetId)
        {
            return await _service.AssignmentHistoricals(assetId);
        }

        [Authorize(Role.Admin)]
        [HttpGet("get-by-location")]
        public async Task<ActionResult<List<AssignmentDTO>>> GetAssignmentByLocation(int userId)
        {
            return await _service.GetAssignmentByLocation(userId);
        }

        [Authorize(Role.Admin, Role.Staff)]
        [HttpGet("detail")]
        public async Task<AssignmentDTO> GetAssignmentById(int assignmentId)
        {
            return await _service.GetAssignmentById(assignmentId);
        }

        [Authorize(Role.Admin, Role.Staff)]
        [HttpGet("get-by-user-id")]
        public async Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId)
        {
            return await _service.GetAssignmentByUserId(userId);
        }

        [Authorize(Role.Admin)]
        [HttpPut("update")]
        public async Task UpdateAssignment([FromBody]UpdateAssignmentModel assignment, int assignmentId)
        {
            await _service.UpdateAssignment(assignment, assignmentId);
        }

        [Authorize(Role.Admin)]
        [HttpPut("complete")]
        public async Task CompleteAssignment(int assignmetnId)
        {
            await _service.CompleteAssignment(assignmetnId);
        }

        [Authorize(Role.Admin, Role.Staff)]
        [HttpPut("apccept")]
        public async Task AcceptAssignment(int assignmetnId)
        {
            await _service.AcceptAssignment(assignmetnId);
        }

        [Authorize(Role.Admin, Role.Staff)]
        [HttpPut("reject")]
        public async Task RejectAssignment(int assignmentId)
        {
            await _service.RejectAssignment(assignmentId);
        }
    }
}