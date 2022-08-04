using backend.Entities;
using backend.Enums;

namespace backend.Data
{
    public static class SeedingData
    {
        public static IEnumerable<Category> SeedingCategories
        {
            get
            {
                IEnumerable<Category> result = new List<Category>() {
                    new Category() {
                        CategoryId = 1,
                        CategoryName = "Laptop",
                        Prefix = "LA"
                    },
                    new Category() {
                        CategoryId = 2,
                        CategoryName = "Monitor",
                        Prefix = "MO"
                    },
                    new Category() {
                        CategoryId = 3,
                        CategoryName = "Personal Computer",
                        Prefix = "PC"
                    },
                };
                return result;
            }
        }
        public static IEnumerable<Asset> SeedingAssets
        {
            get
            {
                IEnumerable<Asset> result = new List<Asset>() {
                    new Asset() {
                        AssetId = 1,
                        CategoryId = 1,
                        CategoryName = "Laptop",
                        AssetName = "HP Zenbook8",
                        AssetCode = "LA1",
                        Specification ="this is sample data",
                        Location = "sample location",
                        InstalledDate = DateTime.Now,
                        AssetState = AssetState.Available,
                    },
                    new Asset() {
                        AssetId = 2,
                        CategoryId = 2,
                        CategoryName = "Monitor",
                        AssetName = "Dell UltralSharp",
                        AssetCode = "MO1",
                        Specification ="this is sample data",
                        Location = "sample location",
                        InstalledDate = DateTime.Now,
                        AssetState = AssetState.Available
                    },
                    new Asset() {
                        AssetId =3,
                        CategoryId = 3,
                        CategoryName = "Personal Computer",
                        AssetName = "HP PC",
                        AssetCode = "PC1",
                        Specification="this is sample data",
                        Location = "sample location",
                        InstalledDate = DateTime.Now,
                        AssetState = AssetState.Available
                    },
                };
                return result;
            }
        }
        public static IEnumerable<User> SeedingUsers
        {
            get
            {
                IEnumerable<User> result = new List<User>() {
                    new User() {
                        UserId = 1,
                        UserName = "Admin",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Admin"),
                        FirstName="Dao",
                        LastName="Quy Vuong",
                        Gender = Gender.Male,
                        Location = Location.Hanoi,
                        IsFirstLogin = true,
                        StaffCode = "AD1",
                        Role = Role.Admin,
                        JoinedDate = DateTime.Now,
                        DateOfBirth = new DateTime(2000,2,23),
                        UserState = UserState.Active
                    },
                    new User() {
                        UserId =2,
                        UserName = "Staff",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Staff"),
                        FirstName="Bui",
                        LastName="Chi Huong",
                        Gender = Gender.Male,
                        Location = Location.Hanoi,
                        IsFirstLogin = true,
                        StaffCode = "US2",
                        Role = Role.Staff,
                        JoinedDate = DateTime.Now,
                        DateOfBirth = new DateTime(1999,3,26),
                        UserState = UserState.Active
                    },
                    new User() {
                        UserId =3,
                        UserName = "Huong",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Huong"),
                        FirstName="Bui",
                        LastName="Chi Huong",
                        Gender = Gender.Female,
                        Location = Location.HCM,
                        IsFirstLogin = true,
                        StaffCode = "........",
                        Role = Role.Staff,
                        JoinedDate = DateTime.Now,
                        DateOfBirth = new DateTime(2001,3,26),
                        UserState = UserState.Disable
                    },
                };
                return result;
            }
        }
        public static IEnumerable<Assignment> SeedingAssignment
        {
            get
            {
                IEnumerable<Assignment> result = new List<Assignment>() {
                    new Assignment() {
                        AssignmentId = 2,
                        AssignedByUserId = 1,
                        AssignedByUserName = "Admin",
                        AssignedToUserId = 2,
                        AssignedToUserName = "Staff",
                        AssetId = 1,
                        AssetName = "Changed",
                        AssetCode = "MO000002",
                        Specification="",
                        AssignedDate = DateTime.Now,
                        Note = "seeding data",
                        Location = "Hanoi",
                    },
                    new Assignment() {
                        AssignmentId = 3,
                        AssignedByUserId = 1,
                        AssignedByUserName = "Admin",
                        AssignedToUserId = 2,
                        AssignedToUserName = "Staff",
                        AssetId = 2,
                        AssetName = "Dell Vostro3578",
                        AssetCode = "PC000007",
                        Specification = "",
                        AssignedDate = DateTime.Now,
                        Note = "seeding data",
                        Location = "Hanoi"
                    },
                };
                return result;
            }
        }
    }
}