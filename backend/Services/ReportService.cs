using backend.Data;
using backend.Entities;
using backend.Enums;
using backend.Interfaces;
using backend.Models.Report;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace backend.Services
{
    public class ReportService : IReportService
    {
        private MyDbContext _context;
        public ReportService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<ReportModel>> Report()
        {
            try
            {
                if (_context.Categories != null)
                {
                    //get all categories
                    Category[] allCategories = _context.Categories.Include(x => x.Assets).ToArray();
                    
                    //create a <ReportModel> list
                    List<ReportModel> reports = new List<ReportModel>();
                    for (int i = 0; i < allCategories.Count(); i++)
                    {
                        //Find asset with founded category
                        var foudAssets = allCategories[i].Assets;
                        //Count totlal asset in founded category
                        int countTotal = foudAssets.Count();
                        //Count asset with state Assigned
                        int countAssigned = foudAssets.Where(x => x.AssetState == AssetState.Assigned).Count();
                        //Count asset in state available
                        int countAvailble = foudAssets.Where(x => x.AssetState == AssetState.Available).Count();
                        //Count asset with state NotAvailable
                        int countNotAvailable = foudAssets.Where(x => x.AssetState == AssetState.NotAvailable).Count();
                        //Count asset with state Waiting....
                        int countWaitingForRecycling = foudAssets.Where(x => x.AssetState == AssetState.WaitingForRecycling).Count();
                        //Count asset with state Recycled
                        int countRecyled = foudAssets.Where(x => x.AssetState == AssetState.Recycled).Count();
                        //Create new report model
                        ReportModel model = new ReportModel()
                        {
                            CategoryName = allCategories[i].CategoryName,
                            Total = countTotal,
                            Available = countAvailble,
                            Assigned = countAssigned,
                            NotAvailable = countNotAvailable,
                            Recycled = countRecyled,
                        };
                        //add into <ReportModel> list
                        reports.Add(model);
                    };
                    return reports;
                }
                return null;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}