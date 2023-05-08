using Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Mocks
{
    public class MockCatagory : ICategory
    {
        public IEnumerable<Category> Categories {
            get 
            {
                return new List<Category> {
                    new Category
                    {
                        Name = "Woman",
                        CategoryType = CategoryType.Woman,
                        Description = "Every woman will find something for herself",
                    },
                    new Category
                    {
                        Name = "Man",
                        CategoryType = CategoryType.Man,
                        Description = "Every man will find something for himself",
                    },
                    new Category
                    {
                        Name = "Child",
                        CategoryType = CategoryType.Child,
                        Description = "The best clothes for your children",
                    }
                };
            }
        }
    }
}
