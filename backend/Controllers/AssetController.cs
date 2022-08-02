using backend.Interfaces;
using backend.DTO;
using backend.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Assets;
using backend.Enums;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private IAssetService _service;
        public AssetController(IAssetService service)
        {
            _service = service;
        }
        
        [Authorize(Role.Admin)]
        [HttpPost("add")]
        public async Task AddAsset([FromBody] AssetCreateModel asset, int userId)
        {
            await _service.AddAsset(asset, userId);
        }

        [Authorize(Role.Admin)]
        [HttpPut("update")]
        public async Task UpdateAsset([FromBody] AssetUpdateModel asset, int id)
        {
            await _service.UpdateAsset(asset, id);
        }
        
        [Authorize(Role.Admin)]
        [HttpDelete("delete")]
        public async Task DeleteAsset(int assetId)
        {
            await _service.DeleteAsset(assetId);
        }

        [Authorize(Role.Admin)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDTO>> GetAssetById(int id)
        {
            return await _service.GetAssetById(id);
        }

        [Authorize(Role.Admin)]
        [HttpGet("all")]
        public async Task<ActionResult<List<AssetDTO>>> GetAllValidAsset(int userId)
        {
            return await _service.GetAllValidAsset(userId);
        }
    }
}