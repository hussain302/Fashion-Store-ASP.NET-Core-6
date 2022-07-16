using FashionStore.Data.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Repositories.IRepositories
{
    public interface IOrderStatusRepository
    {
        public List<OrderStatus> GetOrderStatuss();
        public OrderStatus GetOrderStatus(int id);
        public void AddOrderStatus(OrderStatus OrderStatus);
        public void UpdateOrderStatus(OrderStatus item);
        public void DeleteOrderStatus(int id);

    }
}
