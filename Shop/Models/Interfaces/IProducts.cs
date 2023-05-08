using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Interfaces
{
    public interface IProducts
    {
        public IEnumerable<Product> products { get; }
        public Product GetProduct(int id);
    }
}
