namespace FashionStore.Model.Models
{
    public class CartItemModel
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public double ItemPrice { get; set; }

        public double Total { get; set; }
        public int? Quantity { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

    }
}
