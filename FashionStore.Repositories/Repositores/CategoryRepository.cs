using FashionStore.Data;
using FashionStore.Data.Products;
using FashionStore.Repositories.IRepositories;

namespace FashionStore.Repositories.Repositores
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FashionContext context;

        public CategoryRepository(FashionContext context)
        {
            this.context = context;
        }

        public void AddCategory(ProductCategory category)
        {
            category.CreatedAt = DateTime.Now;
            context.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var find = GetCategory(id);
            if (find != null)
            {
                context.Remove(find);
                context.SaveChanges();
            }
        }

        public List<ProductCategory> GetCategories()
        {
            return context.ProductCategories.ToList();
        }

        public ProductCategory GetCategory(int id)
        {
            return context.ProductCategories.Find(id);
        }

        public void UpdateCategory(ProductCategory category)
        {
            category.UpdatedAt = DateTime.Now;
            if(category != null)
            {
                context.Update(category);
                context.SaveChanges();
            }
        }
    }
}
