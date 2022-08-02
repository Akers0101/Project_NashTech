namespace backend.DTO
{
    public class ReturningRequestDTO
    {
        public int RequestId { get; set; }
        public int RequestedByUserId { get; set; }
        public int ProcessedByUserId { get; set; }
        public int AssignmentId { get; set; }
        public string RequestState { get; set; }
    }
}