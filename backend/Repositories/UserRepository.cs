using backend.Data;
using backend.DTO;
using backend.Entities;
using backend.Enums;
using backend.Helpers;
using backend.Models.Users;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(UserCreateModel user, int userId);
        public Task UpdateUser(UserUpdateModel user, int userId);
        public Task DeleteUser(int id);
        public Task DisableUser(int id);
        public Task ChangePasswordFirstLogin(FirstLogin login);
        public Task ChangePassWord(ChangePassword changePassword);
        public Task<List<UserDTO>> GetAllActiveUser(int userId);
        public Task<User> GetUserById(int id);
    }
    public class UserRepository : IUserRepository
    {
        private MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        private bool checkValidPassowrd(string password)
        {
            int countSpace = 0;
            string str1;
            for (int i = 0; i < password.Length; i++)
            {
                str1 = password.Substring(i, 1);
                if (str1 == " ")
                    countSpace++;
            }

            if (countSpace > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool CheckAssignment(int userId)
        {
            var foundUser = _context.Users.Include(x => x.AssignedTo).FirstOrDefault(x => x.UserId == userId);
            var foudAssignment = foundUser.AssignedTo;
            if (!foudAssignment.Any()
                || foudAssignment.All(x => x.AssignmentState == AssignmentState.Returned))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckJoinedDate(DateTime date)
        {
            if (DateTime.Compare(DateTime.Now, date) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckDateOfBirth(DateTime date)
        {
            if (DateTime.Compare(DateTime.Now, date) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string GenerateStaffCode()
        {
            var lastUserId = _context.Users?.OrderByDescending(o => o.UserId).FirstOrDefault()?.UserId + 1;
            var userId = "SD" + String.Format("{0,0:D4}", lastUserId++);
            return userId;
        }

        private string GenerateUserName(string? firstname, string? lastname)
        {
            var prefix = "";
            var postfix = "";
            if (lastname == null)
            {
                prefix = "";
            }
            else
            {
                var lastnames = lastname.Trim().Split(' ');
                foreach (var fn in lastnames)
                {
                    prefix += fn.Trim();
                }
            }

            if (firstname == null)
            {
                postfix = "";
            }
            else
            {
                var firstnames = firstname.Trim().Split(' ');
                foreach (var ln in firstnames)
                {
                    if (ln != "") postfix += ln.Trim().Substring(0, 1);
                }
            }

            var rawusername = (prefix + postfix).ToLower();

            //generate code
            var check = _context.Users.Any(o => o.UserName.Equals(rawusername));
            if (check)
            {
                var postNumber = 0;
                var flag = true;
                var username = "";
                do
                {
                    postNumber++;
                    username = rawusername + postNumber.ToString();
                    flag = CheckUsernameDb(username);
                } while (flag);
                return username;
            }
            else
            {
                return rawusername;
            }

        }

        private bool CheckUsernameDb(string username)
        {
            if (_context.Users.Any(o => o.UserName.Equals(username)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GeneratePassword(string username, DateTime dateOfBirth)
        {
            return username + "@" + dateOfBirth.ToString("ddMMyyyy");
        }

        public async Task AddUser(UserCreateModel user, int userId)
        {
            try
            {
                if (!CheckDateOfBirth(user.DateOfBirth))
                {
                    throw new AppException("Date of birth is in the future");
                }
                if (DateTime.Parse(user.JoinedDate).DayOfWeek == DayOfWeek.Saturday
                    || DateTime.Parse(user.JoinedDate).DayOfWeek == DayOfWeek.Sunday)
                {
                    throw new AppException("Joined date is Saturday or Sunday. Please select a different date");
                }
                if (!CheckJoinedDate(DateTime.Parse(user.JoinedDate)))
                {
                    throw new AppException("Joined date is in the future");
                }
                if (DateTime.Parse(user.JoinedDate).Year - user.DateOfBirth.Year < 18)
                {
                    throw new AppException("User is under 18. Please select a different date");
                }

                var foundUser = await _context.Users.FindAsync(userId);
                if (foundUser != null)
                {
                    var username = GenerateUserName(user.FirstName, user.LastName);
                    DateTime dateTimeParseResult;
                    var newUser = new User
                    {
                        UserName = username,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(GeneratePassword(username, user.DateOfBirth)),
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = !user.Gender.Equals("Male") ? Gender.Female : Gender.Male,
                        Location = foundUser.Location,
                        IsFirstLogin = true,
                        StaffCode = GenerateStaffCode(),
                        Role = !user.Role.Equals("Staff") ? Role.Admin : Role.Staff,
                        DateOfBirth = user.DateOfBirth,
                        JoinedDate = DateTime.TryParse(user.JoinedDate, out dateTimeParseResult)
                        ? dateTimeParseResult
                        : DateTime.Now,
                        UserState = UserState.Active
                    };
                    await _context.Users.AddAsync(newUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ChangePassWord(ChangePassword changePassword)
        {
            try
            {
                var foundUser = _context.Users.FirstOrDefault(user => user.UserName == changePassword.UserName);
                if (!BCrypt.Net.BCrypt.Verify(changePassword.OldPassword, foundUser.PasswordHash)) throw new AppException("Wrong old password");
                if (changePassword.OldPassword == changePassword.NewPassword) throw new AppException("New password has to be different from old password");
                if (changePassword.NewPassword.Length > 255) throw new AppException("Password should less than 255 characters");
                if (changePassword.NewPassword.Length < 8) throw new AppException("Password should have more than 8 characters");
                if (!checkValidPassowrd(changePassword.NewPassword)) throw new AppException("Password should not have any space");
                if (foundUser != null)
                {
                    foundUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(changePassword.NewPassword);

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ChangePasswordFirstLogin(FirstLogin login)
        {
            try
            {
                var foundUser = _context.Users.FirstOrDefault(x => x.UserName == login.UserName);
                if (BCrypt.Net.BCrypt.Verify(login.NewPassword, foundUser.PasswordHash)) throw new AppException("New password has to be different from old password");
                if (login.NewPassword.Length > 255) throw new AppException("Your password should less than 255 chatacters");
                if (login.NewPassword.Length < 8) throw new AppException("Your password should more than 8 chatacters");
                if (!checkValidPassowrd(login.NewPassword)) throw new AppException("Password should not have any space");
                if (foundUser.IsFirstLogin == false) throw new AppException("This is not your first login");
                if (foundUser != null

                    && login.NewPassword.Length > 8
                    && login.NewPassword.Length < 255)
                {
                    foundUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(login.NewPassword);
                    foundUser.IsFirstLogin = false;

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                var foundUser = await _context.Users.FindAsync(id);
                if (foundUser != null)
                {
                    _context.Users.Remove(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            var foundUser = await _context.Users.FindAsync(id);
            if (foundUser != null)
            {
                return foundUser;
            }
            return null;
        }

        public async Task UpdateUser(UserUpdateModel user, int userId)
        {
            try
            {
                if (!CheckDateOfBirth(DateTime.Parse(user.DateOfBirth)))
                {
                    throw new AppException("Date of birth is in the future");
                }
                if (DateTime.Parse(user.JoinedDate).DayOfWeek == DayOfWeek.Saturday
                    || DateTime.Parse(user.JoinedDate).DayOfWeek == DayOfWeek.Sunday)
                {
                    throw new AppException("Joined date is Saturday or Sunday. Please select a different date");
                }
                if (!CheckJoinedDate(DateTime.Parse(user.JoinedDate)))
                {
                    throw new AppException("Joined date is in the future");
                }
                if (DateTime.Parse(user.JoinedDate).Year - DateTime.Parse(user.DateOfBirth).Year < 18)
                {
                    throw new AppException("User is under 18. Please select a different date");
                }

                var foundUser = await _context.Users.FindAsync(userId);
                if (foundUser != null)
                {
                    DateTime dateTimeBirthResult;
                    DateTime dateTimeJoinedResult;
                    foundUser.Gender = !user.Gender.Equals("Male") ? Gender.Female : Gender.Male;
                    foundUser.DateOfBirth = DateTime.TryParse(user.DateOfBirth, out dateTimeBirthResult)
                    ? dateTimeBirthResult
                    : DateTime.Now;
                    foundUser.JoinedDate = DateTime.TryParse(user.JoinedDate, out dateTimeJoinedResult)
                    ? dateTimeJoinedResult
                    : DateTime.Now;
                    foundUser.Role = !user.Role.Equals("Admin") ? Role.Staff : Role.Admin;

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                };

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DisableUser(int id)
        {
            try
            {
                var foundUser = _context.Users.FirstOrDefault(user => user.UserId == id);
                if (CheckAssignment(id)) throw new AppException("There are valid assignments belonging to this user. Please close all assignments before disabling user.");
                if (foundUser != null)
                {
                    foundUser.UserState = UserState.Disable;
                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UserDTO>> GetAllActiveUser(int userId)
        {
            var item = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if (item != null)
            {
                var users = _context.Users.Where(x => x.UserState == UserState.Active && x.Location == item.Location);
                if (users != null)
                {
                    return await users.Select(x => x.UserEntityToDTO()).ToListAsync();
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}