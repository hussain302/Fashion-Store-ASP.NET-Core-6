using FashionStore.Data.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        public List<ProductCategory> GetCategories();
        public ProductCategory GetCategory(int id);
        public void AddCategory(ProductCategory category);
        public void UpdateCategory(ProductCategory category);
        public void DeleteCategory(int id);

    }
}
