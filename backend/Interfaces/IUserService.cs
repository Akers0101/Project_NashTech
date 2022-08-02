using backend.DTO;
using backend.Entities;
using backend.Models.Users;

namespace backend.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        public Task AddUser(UserCreateModel user, int userId);
        public Task UpdateUser(UserUpdateModel user, int userId);
        public Task DeleteUser(int id);
        public Task ChangePasswordFirstLogin(FirstLogin login);
        public Task ChangePassWord(ChangePassword changePassword);
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public Task DisableUser(int id);
        public Task<List<UserDTO>> GetAllActiveUser(int userId);
    }
}