
namespace FashionStore.Model.Models
{
    public class OrderModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }
        public DateTime OrderAssignedDate { get; set; }
        public DateTime ExpectedDeliveryDate  { get; set; }



        public int StatusId { get; set; }
        public virtual OrderStatusModel Status { get; set; }

        public int UserId { get; set; }
        public virtual UserModel User { get; set; }

        public int CartId { get; set; }
        public virtual CartModel Cart { get; set; }

    }
}
