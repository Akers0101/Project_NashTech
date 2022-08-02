namespace backend.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public bool IsFirstLogin { get; set; }
        public string? StaffCode { get; set; }
        public string DateOfBirth { get; set; }
        public string UserState { get; set; }
        public string FullName {get;set;}
    }
}