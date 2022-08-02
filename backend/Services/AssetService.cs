using backend.Interfaces;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Assets;
using backend.Repositories;

namespace backend.Services
{
    public class AssetService : IAssetService
    {
        private IAssetRepository _repository;
        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsset(AssetCreateModel asset, int userId)
        {
            await _repository.AddAsset(asset, userId);
        }

        public async Task DeleteAsset(int id)
        {
            await _repository.DeleteAsset(id);
        }

        public async Task<ActionResult<List<AssetDTO>>> GetAllValidAsset(int userId)
        {
            return await _repository.GetAllValidAsset(userId);
        }

        public async Task<ActionResult<AssetDTO>> GetAssetById(int id)
        {
            return await _repository.GetAssetById(id);
        }

        public async Task UpdateAsset(AssetUpdateModel asset, int assetId)
        {
            await _repository.UpdateAsset(asset, assetId);
        }
    }
}