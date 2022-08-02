using backend.Data;
using backend.DTO;
using backend.Entities;
using backend.Enums;
using backend.Helpers;
using backend.Models.Assets;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public interface IAssetRepository
    {
        public Task AddAsset(AssetCreateModel asset, int userId);
        public Task UpdateAsset(AssetUpdateModel asset, int assetId);
        public Task DeleteAsset(int id);
        public Task<ActionResult<AssetDTO>> GetAssetById(int id);
        public Task<ActionResult<List<AssetDTO>>> GetAllValidAsset(int userId);

    }
    public class AssetRepository : IAssetRepository
    {
        private MyDbContext _context;
        public AssetRepository(MyDbContext context)
        {
            _context = context;
        }

        private bool CheckInstalledDate(DateTime date)
        {
            if (DateTime.Now.Date >= date.Date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckValidCategory(int categoryId)
        {
            return _context.Categories.Any(c => c.CategoryId == categoryId);
        }

        private bool CheckUser(int userId)
        {
            return _context.Users.Any(u => u.UserId == userId);
        }

        private string GenerateAssetCode(int categoryId)
        {
            var prefix = _context.Categories.Find(categoryId).Prefix;
            var sameCatalogue = _context.Assets.Where(a => a.CategoryId == categoryId);
            if (sameCatalogue.Count() == 0)
            {
                return prefix + "000001";
            }
            else
            {
                var lastAssetCode = sameCatalogue.OrderByDescending(o => o.AssetId).FirstOrDefault()?.AssetCode;
                var lastAssetId = Convert.ToInt32(lastAssetCode?.Substring(lastAssetCode.Length - 6)) + 1;
                return prefix + String.Format("{0,0:D6}", lastAssetId++);
            }
        }

        public async Task AddAsset(AssetCreateModel asset, int userId)
        {
            try
            {
                if (!CheckValidCategory(asset.CategoryId)) throw new AppException("CategoryId is not valid");
                if (!CheckInstalledDate(DateTime.Parse(asset.InstalledDate))) throw new AppException("Installed Date must not be in the future");
                if (!CheckUser(userId)) throw new AppException("Undentify user");
                var foundUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                var foundCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == asset.CategoryId);
                if (foundCategory != null && foundUser != null)
                {
                    DateTime dateTimeParseResult;
                    var newAsset = new Asset
                    {
                        AssetCode = GenerateAssetCode(asset.CategoryId),
                        AssetName = asset.AssetName,
                        CategoryId = asset.CategoryId,
                        CategoryName = foundCategory.CategoryName,
                        Specification = asset.Specification,
                        InstalledDate = DateTime.TryParse(asset.InstalledDate, out dateTimeParseResult)
                        ? dateTimeParseResult
                        : DateTime.Now,
                        Location = foundUser.Location.ToString(),
                        AssetState = asset.AssetState.Equals("Available") ? AssetState.Available : AssetState.NotAvailable
                    };
                    await _context.Assets.AddAsync(newAsset);
                    await _context.SaveChangesAsync();
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteAsset(int id)
        {
            try
            {
                var foundAsset = await _context.Assets.FindAsync(id);
                var foundAssignment = _context.Assignments.Any(x => x.AssetId == foundAsset.AssetId);
                if (foundAssignment) throw new AppException("Cannot delete the asset because it belongs to one or more historical assignments.If the asset is not able to be used anymore, please update its state in");
                if (foundAsset != null)
                {
                    _context.Assets.Remove(foundAsset);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ActionResult<List<AssetDTO>>> GetAllValidAsset(int userId)
        {
            if (_context.Assets != null)
            {
                try
                {
                    var foundUser = _context.Users.FirstOrDefault(x => x.UserId == userId);
                    if (foundUser != null)
                    {
                        var assets = await _context.Assets
                            .Where(assets => assets.AssetState != AssetState.Recycled
                                            && assets.AssetState != AssetState.WaitingForRecycling
                                            && assets.Location == foundUser.Location.ToString())
                            .Select(asset => asset.AssetEntityToDTO())
                            .ToListAsync();
                        return new OkObjectResult(assets);
                    }
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<AssetDTO>> GetAssetById(int id)
        {
            if (_context.Assets != null)
            {
                try
                {
                    var foundAsset = await _context.Assets.FindAsync(id);
                    if (foundAsset != null)
                        return new OkObjectResult(foundAsset.AssetEntityToDTO());
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }

        public async Task UpdateAsset(AssetUpdateModel asset, int assetId)
        {
            try
            {
                DateTime dateTimeParseResult;
                var foundAsset = await _context.Assets.FindAsync(assetId);
                if (!CheckInstalledDate(DateTime.Parse(asset.InstalledDate))) throw new AppException("Installed Date must not be in the future");
                if (foundAsset != null)
                {
                    foundAsset.AssetName = asset.AssetName;
                    foundAsset.InstalledDate = DateTime.TryParse(asset.InstalledDate, out dateTimeParseResult)
                        ? dateTimeParseResult
                        : DateTime.Now;

                    foundAsset.Specification = asset.Specification;

                    if (asset.AssetState.Equals("Not Available"))
                    {
                        foundAsset.AssetState = AssetState.NotAvailable;
                    }
                    else if (asset.AssetState.Equals("Waiting For Recycling"))
                    {
                        foundAsset.AssetState = AssetState.WaitingForRecycling;
                    }
                    else if (asset.AssetState.Equals("Recycled"))
                    {
                        foundAsset.AssetState = AssetState.Recycled;
                    }
                    else
                    {
                        foundAsset.AssetState = AssetState.Available;
                    }

                    _context.Assets.Update(foundAsset);
                    await _context.SaveChangesAsync();
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}