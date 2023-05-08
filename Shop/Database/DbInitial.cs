using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Models.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class DbInitial
    {
        public static void Initial(AppDBContent dBContent)
        {
            if (false)
            {
                var entities = dBContent.Categories.ToList();
                dBContent.Categories.RemoveRange(entities);

                var ent = dBContent.Products.ToList();
                dBContent.Products.RemoveRange(ent);

                dBContent.SaveChanges();
            }
            if (!dBContent.Database.CanConnect()) return;
            
            if (!dBContent.Categories.Any())
            {
                dBContent.Categories.AddRange(new MockCatagory().Categories);
            }
            if (!dBContent.Products.Any())
            {
                dBContent.Products.AddRange(new MockProducts().products);
            }

            dBContent.SaveChanges();
        }
    }
}
