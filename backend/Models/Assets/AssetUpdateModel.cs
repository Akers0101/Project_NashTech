namespace backend.Models.Assets
{
    public class AssetUpdateModel
    {
        public string? AssetName { get; set; }
        public string Specification { get; set; }
        public string InstalledDate { get; set; }
        public string AssetState { get; set; }
    }
}