using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cacheAssignment
{
    class ProductService : IProductService
    {
        public List<Product> GetAllProducts()
        {
            IRepository productRepo = new DBRepository();
            return productRepo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            IRepository productRepo = new DBRepository();
            return productRepo.GetProductById(id);
        }
    }
}
