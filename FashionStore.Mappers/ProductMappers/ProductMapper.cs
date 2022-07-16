using FashionStore.Data.Products;
using FashionStore.Model.Models;

namespace FashionStore.Mappers.ProductMappers
{
    public static class ProductMapper
    {

        #region View for products

        public static ProductModel ConvertToWebMenORWomenModel(this Product source)
        {


            return new ProductModel
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Fabric = source.Fabric,
                //IsFeatured = source.IsFeatured,
                Quantity = source.Quantity,
                TypeId = source.TypeId,
                Price = source.Price,
                ImageModelURL = source.ImageURL,
                ProductCategory = source.ProductCategory.ConvertToWebModel(),
                ProductType = source.ProductType.ConvertToWebModel(),
            };
        }

        public static ProductModel ConvertToFragranceViewModel(this Product source)
        {


            return new ProductModel
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                CategoryId = source.CategoryId,
                //Fabric = source.Fabric,
                //IsFeatured = source.IsFeatured,
                Quantity = source.Quantity,
                TypeId = source.TypeId,
                Price = source.Price,
                ImageModelURL = source.ImageURL,
                ProductCategory = source.ProductCategory.ConvertToWebModel(),
                ProductType = source.ProductType.ConvertToWebModel(),
            };
        }


        #endregion


        #region Main Mappers

        public static ProductModel ConvertToWebModel(this Product source)
        {
            return new ProductModel
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Fabric = source.Fabric,
                IsFeatured=source.IsFeatured,
                Quantity = source.Quantity,
                TypeId = source.TypeId,
                Price = source.Price,
                ImageModelURL = source.ImageURL,
                ProductCategory = source.ProductCategory.ConvertToWebModel(),
                ProductType = source.ProductType.ConvertToWebModel(),
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }




        public static Product ConvertToDomainModel(this ProductModel source)
        {
            return new Product
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                CategoryId = source.CategoryId,
                Fabric = source.Fabric,
                ImageURL = source.ImageModelURL,
                IsFeatured = source.IsFeatured,
                Quantity = source.Quantity,
                TypeId = source.TypeId,
                Price = source.Price,
                //ProductCategory = source.ProductCategory.ConvertToDomainModel(),
                //ProductType = source.ProductType.ConvertToDomainModel(),
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                UpdatedAt = source.UpdatedAt,
                UpdatedBy = source.UpdatedBy
            };
        }

        #endregion

    }
}
