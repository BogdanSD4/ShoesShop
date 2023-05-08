using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Interfaces
{
    public interface ICategory
    {
        public IEnumerable<Category> Categories { get; }
    }
}
