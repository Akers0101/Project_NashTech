namespace backend.DTO
{
    public class AssignmentDTO
    {
        public int AssignmentId { get; set; }
        public int AssetId { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string Specification { get; set; }
        public string AssignedByUserName { get; set; }
        public int AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Note { get; set; }
        public string AssignmentState { get; set; }
        public string Location { get; set; }
    }
}