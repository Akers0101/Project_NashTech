using backend.Models.Report;
using backend.Authorization;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Enums;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<List<ReportModel>> Report()
        {
            return await _service.Report();
        }
    }
}