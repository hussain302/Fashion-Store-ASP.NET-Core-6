using FashionStore.Model.Models;

namespace FashionStore.WebUI.Models
{
    public class ModelHelperCart
    {
        private static List<CartItemModel> cartItems;
        static ModelHelperCart()
        {
            cartItems = new List<CartItemModel>();
        }
        public List<CartItemModel> GetCartItems()
        {
            return cartItems;
        }
        public void AddCartItem(CartItemModel model)
        {  
            cartItems.Add(model);
        }
        public void RemoveCartItem(int id)
        {
            int itemIndex = cartItems.FindIndex(x => x.ItemId == id);
            cartItems.RemoveAt(itemIndex);
        }
        public void ClearCartItems()
        {
            cartItems.Clear();
        }
        public CartItemModel GetCartItemById(int id)
        {
            var find = cartItems.Find(x => x.ItemId == id);
            return find;
        }
    }
}
