using FashionStore.Data.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Repositories.IRepositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrders();
        public Order GetOrder(int id);
        public void AddOrder(Order model);
        public void RemoveOrder(int id);
        public void UpdateOrder(Order model);
        public void ApproveOrder(int id);
        public void DeliveredOrder(int id);
    }
}
