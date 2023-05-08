using Shop.Models;
using Shop.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModel
{
	public class AdminPagesViewModel
	{
		public Customer customer { get; set; }
		public ShopCart[] carts { get; set; }
		public ClientAuth auth { get; set; }
	}
}
