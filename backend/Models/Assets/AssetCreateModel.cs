namespace backend.Models.Assets
{
    public class AssetCreateModel
    {
        public string? AssetName { get; set; }
        public int CategoryId { get; set; }
        public string Specification { get; set; }
        public string Location { get; set; }
        public string InstalledDate { get; set; }
        public string AssetState { get; set; }
    }
}