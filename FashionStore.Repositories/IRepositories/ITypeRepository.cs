using FashionStore.Data.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Repositories.IRepositories
{
    public interface ITypeRepository
    {
        public List<ProductType> GetTypes();
        public ProductType GetType(int id);
        public void AddType(ProductType Type);
        public void UpdateType(ProductType Type);
        public void DeleteType(int id);

    }
}
