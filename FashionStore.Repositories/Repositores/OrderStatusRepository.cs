using FashionStore.Data;
using FashionStore.Data.Products;
using FashionStore.Repositories.IRepositories;

namespace FashionStore.Repositories.Repositores
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly FashionContext context;

        public OrderStatusRepository(FashionContext context)
        {
            this.context = context;
        }

        public void AddOrderStatus(OrderStatus OrderStatus)
        {
            context.OrderStatuses.Add(OrderStatus);
            context.SaveChanges();
        }

        public void DeleteOrderStatus(int id)
        {
            var find = GetOrderStatus(id);
            context.OrderStatuses.Remove(find);
            context.SaveChanges();
        }

        public OrderStatus GetOrderStatus(int id)
        {
           return context.OrderStatuses.Find(id);
        }

        public List<OrderStatus> GetOrderStatuss()
        {
           return context.OrderStatuses.ToList();
        }

        public void UpdateOrderStatus(OrderStatus item)
        {
            if(item != null)
            {
                context.Update<OrderStatus>(item);
                context.SaveChanges();
            }
        }
    }
}
