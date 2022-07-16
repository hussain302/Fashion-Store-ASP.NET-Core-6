using System.ComponentModel.DataAnnotations;

namespace FashionStore.Data.Products
{
    public class OrderStatus
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
