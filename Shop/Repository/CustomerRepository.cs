using Shop.Database;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository
{
    public class CustomerRepository : DBRepository
    {
        public CustomerRepository(AppDBContent dBContent) : base(dBContent)
        {
            _customers = dBContent.Customers;
        }

        private IEnumerable<Customer> _customers;

        public string this[string customerId] { get 
            {
                int id = _customers.FirstOrDefault(x => x.customerId == customerId).authId;
                return database.ClientAuths.FirstOrDefault(x => x.id == id).usertype;
            }
        }
    }
}
