using FashionStore.Data;
using FashionStore.Data.Products;
using FashionStore.Repositories.IRepositories;

namespace FashionStore.Repositories.Repositores
{
    public class TypeRepository : ITypeRepository
    {
        private readonly FashionContext context;

        public TypeRepository(FashionContext context)
        {
            this.context = context;
        }

        public void AddType(ProductType Type)
        {
            Type.CreatedAt = DateTime.Now;
            context.Add(Type);
            context.SaveChanges();
        }

        public void DeleteType(int id)
        {
            var find = GetType(id);
            if (find != null)
            {
                context.Remove(find);
                context.SaveChanges();
            }
        }

        public List<ProductType> GetTypes()
        {
            return context.ProductTypes.ToList();
        }

        public ProductType GetType(int id)
        {
            return context.ProductTypes.Find(id);
        }

        public void UpdateType(ProductType Type)
        {
            Type.UpdatedAt = DateTime.Now;
            if(Type != null)
            {
                context.Update(Type);
                context.SaveChanges();
            }
        }
    }
}
