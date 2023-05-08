using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class DBRepository
    {
        public AppDBContent database;
        public DBRepository(AppDBContent dBContent)
        {
            database = dBContent;
        }
    }
}
