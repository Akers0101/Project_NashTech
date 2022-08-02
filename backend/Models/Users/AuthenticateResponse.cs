using backend.Entities;

namespace backend.Models.Users
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string IsFirstLogin { get; set; }
        public string StaffCode { get; set; }
        public string Role { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            FullName = user.FirstName + user.LastName;
            Gender = user.Gender.ToString();
            Location = user.Location.ToString();
            IsFirstLogin = user.IsFirstLogin.ToString();
            StaffCode = user.StaffCode;
            Role = user.Role.ToString();
            Token = token;
            JoinedDate = user.JoinedDate;
            DateOfBirth = user.DateOfBirth;
        }
    }
}