using backend.Entities;

namespace backend.DTO
{
    public class AssetDTO
    {
        public int AssetId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string Specification { get; set; }
        public string Location { get; set; }
        public DateTime InstalledDate { get; set; }
        public string AssetState { get; set; }
    }
}