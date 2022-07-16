using FashionStore.Data.Users;
using FashionStore.Model.Models;

namespace FashionStore.Mappers.UserMappers
{
    public static class RoleMapper
    {

        public static RoleModel ConvertToWebModel(this Role source)
        {
            return new RoleModel
            {
                Id = source.Id,
                Name = source.Name,
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                Description = source.Description,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }

        public static Role ConvertToDomainModel(this RoleModel source)
        {
            return new Role
            {
                Id = source.Id,
                Name = source.Name,
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                Description = source.Description,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }
    }
}
