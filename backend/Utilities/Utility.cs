using backend.DTO;
using backend.Entities;
using backend.Enums;
using backend.Models.Assignments;

namespace backend.Utilities
{
    public static class Utility
    {
        public static CategoryDTO CategoryEntityToDTO(this Category entity)
        {
            return new CategoryDTO()
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Perfix = entity.Prefix,
            };
        }

        public static Category CategoryDTOToEntity(this CategoryDTO category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Prefix = category.Perfix,
            };
        }

        public static AssetDTO AssetEntityToDTO(this Asset entity)
        {
            return new AssetDTO()
            {
                AssetId = entity.AssetId,
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                AssetName = entity.AssetName,
                AssetCode = entity.AssetCode,
                Specification = entity.Specification,
                Location = entity.Location,
                InstalledDate = entity.InstalledDate,
                AssetState = entity.AssetState.Equals(AssetState.Assigned) ? "Assigned" :
                                entity.AssetState.Equals(AssetState.Available) ? "Available" :
                                entity.AssetState.Equals(AssetState.NotAvailable) ? "Not Available" :
                                entity.AssetState.Equals(AssetState.WaitingForRecycling) ? "Waiting For Recycling" : "Recycled"
            };
        }

        public static AssignmentDTO AssignmentEntityToDTO(this Assignment entity)
        {
            AssignmentDTO result = new AssignmentDTO
            {
                AssignmentId = entity.AssignmentId,
                AssetId = entity.AssetId,
                AssetName = entity.AssetName,
                AssetCode = entity.AssetCode,
                Specification = entity.Specification,
                AssignedToUserId = entity.AssignedToUserId,
                AssignedToUserName = entity.AssignedToUserName,
                AssignedByUserName = entity.AssignedByUserName,
                AssignedDate = entity.AssignedDate,
                Note = entity.Note,
                AssignmentState = entity.AssignmentState.Equals(AssignmentState.Accepted) ? "Accepted" :
                                    entity.AssignmentState.Equals(AssignmentState.Returned) ? "Returned" :
                                    entity.AssignmentState.Equals(AssignmentState.WaitingForAcceptance) ? "Waiting For Acceptance" : "Rejected",
                Location = entity.Location
            };
            return result;
        }

        public static HistoricalDTO Historical(this Assignment entity)
        {
            HistoricalDTO result = new HistoricalDTO
            {
                Historical = "Assigned to " + entity.AssignedToUserName + " on " + entity.AssignedDate.ToString("dd/MM/yyyy")
            };
            return result;
        }
        
        public static UserDTO UserEntityToDTO(this User entity)
        {
            UserDTO result = new UserDTO
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                PasswordHash = entity.PasswordHash,
                Role = entity.Role.ToString(),
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                JoinedDate = entity.JoinedDate,
                Gender = entity.Gender.ToString(),
                Location = entity.Location.ToString(),
                IsFirstLogin = entity.IsFirstLogin,
                DateOfBirth = entity.DateOfBirth.ToString(),
                StaffCode = entity.StaffCode,
                UserState = entity.UserState.ToString(),
                FullName = entity.FullName
            };
            return result;
        }
    }
}