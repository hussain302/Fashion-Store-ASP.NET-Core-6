
namespace FashionStore.Model.Models
{
    public class ProductTypeModel
    {
  
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        //navigation property
        public virtual ICollection<ProductModel> Products { get; set; }


        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
