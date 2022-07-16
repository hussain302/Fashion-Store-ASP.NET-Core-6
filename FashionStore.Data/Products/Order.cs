

using FashionStore.Data.Users;
using System.ComponentModel.DataAnnotations;

namespace FashionStore.Data.Products
{
    public class Order
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }
        public DateTime OrderAssignedDate { get; set; }
        public DateTime ExpectedDeliveryDate  { get; set; }

        public double TotalPrice { get; set; }
        public int StatusId { get; set; }
        public virtual OrderStatus Status { get; set; }

        public string UserName { get; set; }
        public string Phone { get; set; }
    }
}
