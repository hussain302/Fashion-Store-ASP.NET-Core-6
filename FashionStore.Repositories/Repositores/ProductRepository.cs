using FashionStore.Data;
using FashionStore.Data.Products;
using FashionStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FashionStore.Repositories.Repositores
{
    public class ProductRepository : IProductRepository
    {
        private readonly FashionContext context;
        private readonly int MENS_ID_FK = 2;
        private readonly int WOMENS_ID_FK =1;
        private readonly int KiDS_ID_FK = 3;
        private readonly int FRAGRENCES_ID_FK = 4;

        public ProductRepository(FashionContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            product.CreatedAt = DateTime.Now;
            context.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var find = GetProduct(id);
            if (find != null)
            {
                context.Remove(find);
                context.SaveChanges();
            }
        }

        public List<Product> GetProducts()
        {
            return context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductType).ToList<Product>();
        }

        public Product GetProduct(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return context.Products
                .Include(x => x.ProductCategory).Include(x => x.ProductType)
                .Where(x=>x.Id == id).FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            product.UpdatedAt = DateTime.Now;
            if(product != null)
            {
                context.Update(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetMensProducts()
        {
            return context.Products
                .Include(x => x.ProductCategory).Include(x => x.ProductType)
                .Where(x=>x.CategoryId == MENS_ID_FK).ToList<Product>();
        }

        public List<Product> GetWomensProducts()
        {
            return context.Products
                .Include(x => x.ProductCategory).Include(x => x.ProductType)
                .Where(x => x.CategoryId == WOMENS_ID_FK).ToList<Product>();
        }
        public List<Product> GetFragrancesProducts()
        {
            return context.Products
                .Include(x => x.ProductCategory).Include(x => x.ProductType)
                .Where(x => x.CategoryId == FRAGRENCES_ID_FK).ToList<Product>();
        }
        public List<Product> GetKidsProducts()
        {
            return context.Products
                .Include(x => x.ProductCategory).Include(x => x.ProductType)
                .Where(x => x.CategoryId == KiDS_ID_FK).ToList<Product>();
        }
    }
}
