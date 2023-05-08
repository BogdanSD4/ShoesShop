using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel(string type)
        {
            Type = type;
        }
        public IEnumerable<Customer>? _Custmers { get; set; }
        public string Type { get; private set; }    
    }
}
