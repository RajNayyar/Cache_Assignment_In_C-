using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cacheAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new CacheService();
            List<Product> products = productService.GetAllProducts();
            while (true)
            {
                
                Console.WriteLine("Enter ID you want to retrieve\nEnter -1 to retrieve all products\n-2 to exit");
                int id = int.Parse(Console.ReadLine());
                if (id == -1)
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(products[i].Id + " " + products[i].Name + " " + products[i].Price);
                    }
                }
                else if (id == -2)
                {
                    break;
                }
                else
                {
                    Product product = productService.GetProductById(id);
                    Console.WriteLine(product.Id + " " + product.Name + " " + product.Price);
                }
                Console.WriteLine("------------------------");
            }
        }
    }
}
