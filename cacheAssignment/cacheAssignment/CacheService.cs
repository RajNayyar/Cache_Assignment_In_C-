using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cacheAssignment
{
    class CacheService : IProductService
    {

        private IProductService _proService = new ProductService();
        private Cache _CacheObj = new Cache();


        public Product GetProductById(int id)
        {
            
            Product product = (Product)_CacheObj.GetItemFromCache(Convert.ToString(id));
            if (product != null)
            {
                Console.WriteLine(" Retrieveing From Cache");
                return product;
            }
            else
            {
                product = _proService.GetProductById(id);
                _CacheObj.AddInCache(Convert.ToString(product.Id), product);
            }
            
            return product;

        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = _proService.GetAllProducts();
 
            return products;
        }
    }
}
