
namespace FashionStore.Model.Models
{
    public class CartModel
    {
        public int Id { get; set; }

        public virtual ICollection<CartItemModel> CartItems { get; set; }
        public double  TotalPrice { get; set; }

    }
}
