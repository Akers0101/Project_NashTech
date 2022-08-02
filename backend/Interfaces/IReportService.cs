using backend.Models.Report;

namespace backend.Interfaces
{
    public interface IReportService
    {
        public Task<List<ReportModel>> Report();
    }
}