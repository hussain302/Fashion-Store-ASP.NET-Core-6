using FashionStore.Data;
using FashionStore.Data.Products;
using FashionStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FashionStore.Repositories.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FashionContext context;

        public OrderRepository(FashionContext context)
        {
            this.context = context;
        }

        public void ApproveOrder(int id)
        {
            var find = GetOrder(id);
            find.StatusId = 2;

            context.Update(find);
            context.SaveChanges();
        }
        public void DeliveredOrder(int id)
        {
            var find = GetOrder(id);
            find.StatusId = 4;

            context.Update(find);
            context.SaveChanges();
        }


        public void AddOrder(Order model)
        {
            model.OrderAssignedDate = DateTime.Now;
            model.StatusId = 1;         
            context.Orders.Add(model);
            context.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            var find = context.Orders
                .Include(x => x.Status).
                Where(x => x.Id == id)
                .FirstOrDefault();
            return find;
        }
        public Order GetOrderByUser(string name)
        {
            var find = context.Orders
                .Include(x => x.Status)
               /// .Where(x => x.User.FirstName == name)
                .FirstOrDefault();
            return find;
        }

        public IEnumerable<Order> GetOrders()
        {
            var models = context.Orders
                .Include(x => x.Status).ToList();
            return models;
        }

        public void RemoveOrder(int id)
        {
            var find = GetOrder(id);
            context.Orders.Remove(find);
            context.SaveChanges();
        }


        public void UpdateOrder(Order model)
        {
            if(model != null)
            {
                context.Update(model);
                context.SaveChanges();
            }
        }
    }
}
