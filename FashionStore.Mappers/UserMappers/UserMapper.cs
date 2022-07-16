using FashionStore.Data.Users;
using FashionStore.Model.Models;

namespace FashionStore.Mappers.UserMappers
{
    public static class UserMapper
    {

        public static UserModel ConvertToWebModel (this User source)
        {
            return new UserModel
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Address = source.Address,
                Email = source.Email,
                ImageURL = source.ImageURL,
                IsActive = source.IsActive,
                Password = source.Password,
                RoleId = source.RoleId,
                Role = source.Role.ConvertToWebModel(),
                Phone = source.Phone,
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }
        public static User ConvertToDomainModel(this UserModel source)
        {
            return new User
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Address = source.Address,
                Email = source.Email,
                ImageURL = source.ImageURL,
                IsActive = source.IsActive,
                Password = source.Password,
                RoleId = source.RoleId,
                Phone= source.Phone,
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }


    }
}
