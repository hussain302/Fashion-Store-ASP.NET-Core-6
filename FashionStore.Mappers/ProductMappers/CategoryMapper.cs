using FashionStore.Data.Products;
using FashionStore.Model.Models;

namespace FashionStore.Mappers.ProductMappers
{
    public static class CategoryMapper
    {

        public static ProductCategoryModel ConvertToWebModel(this ProductCategory source)
        {
            return new ProductCategoryModel
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
        public static ProductCategory ConvertToDomainModel(this ProductCategoryModel source)
        {
            return new ProductCategory
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
