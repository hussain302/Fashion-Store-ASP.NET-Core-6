using FashionStore.Data.Products;


namespace FashionStore.Repositories.IRepositories
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public List<Product> GetMensProducts();
        public List<Product> GetWomensProducts();
        public List<Product> GetFragrancesProducts();
        public List<Product> GetKidsProducts();
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
    }
}
