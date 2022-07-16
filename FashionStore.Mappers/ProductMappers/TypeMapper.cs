using FashionStore.Data.Products;
using FashionStore.Model.Models;

namespace FashionStore.Mappers.ProductMappers
{
    public static class TypeMapper
    {

        public static ProductTypeModel ConvertToWebModel(this ProductType source)
        {
            return new ProductTypeModel
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }
        public static ProductType ConvertToDomainModel(this ProductTypeModel source)
        {
            return new ProductType
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }



    }
}
