
using Microsoft.AspNetCore.Http;

namespace FashionStore.Model.Models
{
    public class ProductModel
    {

        public int Id { get; set; }

  
        public string Name { get; set; }

        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public bool? IsFeatured { get; set; }
        public IFormFile? PhotoFile { get; set; }
        public string? ImageModelURL { get; set; }

        public double Price { get; set; }

        public string Fabric { get; set; }


        //Navigation property
        public virtual ICollection<CartModel>  Carts { get; set; }


        //forigen key category of product like, men women etc
        public int CategoryId { get; set; }
        public virtual ProductCategoryModel ProductCategory { get; set; }


        //forigen key Type of product frock, shalwar kameez etc
        public int TypeId { get; set; }
        public virtual ProductTypeModel ProductType { get; set; }


        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
