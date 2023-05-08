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
    public class CategoryRepository : DBRepository, ICategory
    {
        public CategoryRepository(AppDBContent content) : base(content)
        {
        }

        public IEnumerable<Category> Categories => throw new NotImplementedException();
    }
}
