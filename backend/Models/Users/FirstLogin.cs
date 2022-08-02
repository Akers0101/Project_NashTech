using System.Text.Json.Serialization;

namespace backend.Models.Users
{
    public class FirstLogin
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        [JsonIgnore]
        public bool IsFirstLogin { get; set; }
    }
}