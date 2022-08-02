using backend.Enums;

namespace backend.Models.Users
{
    public class UserUpdateModel
    {
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string JoinedDate { get; set; }
        public string Role { get; set; }
    }
}