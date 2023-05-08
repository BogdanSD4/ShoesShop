using Shop.Database;
using Shop.Models;
using Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class ProductRepository : DBRepository, IProducts
    {
        public ProductRepository(AppDBContent content) : base(content)
        {
        }

        public IEnumerable<Product> products { get 
            {
                return database.Products;
            }
        }

        public Product GetProduct(int id)
        {
            return database.Products.First(x => x.id == id);
        }
    }
}
