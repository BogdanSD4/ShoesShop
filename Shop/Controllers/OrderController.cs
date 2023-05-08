using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Models;
using Shop.Models.Cart;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        public readonly AppDBContent content;
        public OrderController(AppDBContent dBContent)
        {
            content = dBContent;
        }

        public IActionResult PlaceOrderForm()
        {
			return PartialView("Views/OrderForm/PlacedOrder.cshtml");
		}

        public IActionResult OrderForm()
        {
            var index = Request.Cookies["UserId"];
            string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{index}.dat";

            dynamic file = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path));
            ShopCart cart = JsonConvert.DeserializeObject<ShopCart>(file["ShopCart"].ToString());

            Customer customer = content.Customers.FirstOrDefault(x => x.customerId == index);

            var list = new
            {
                ShopCart = cart,
                Customer = customer,
            };

            return PartialView("Views/OrderForm/OrderForm.cshtml", list);
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Customer customer)
        {
            var index = Request.Cookies["UserId"];
            string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{index}.dat";

            ShopCart cart = default;
            if (System.IO.File.Exists(path))
            {
                dynamic file = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path));
                cart = JsonConvert.DeserializeObject<ShopCart>(file["ShopCart"].ToString());

                System.IO.File.Delete(path);
            }

            cart.CustomerId = customer.id;
            cart.Date = DateTime.Now;

            content.Customers.Update(customer);
            content.ShopCarts.Add(cart);
            content.SaveChanges();

            content.Orders.Add(new Order { CustomerId = customer.id, ShopCartId = cart.Id});
            content.SaveChanges();

            return Ok();
		}

        [HttpGet]
        public IActionResult OrderPage()
        {
			var index = Request.Cookies["UserId"];
			Customer customer = content.Customers.First(x => x.customerId == index);
            ShopCart[] shopCart = content.ShopCarts.Where(x => x.CustomerId == customer.id).ToArray();

            int shopCartCount = shopCart.Count();
            for (int i = 0; i < shopCartCount; i++)
            {
                shopCart[i].items = content.ShopCartItems.Where(x => x.ShopCartId == shopCart[i].Id).ToList();
            }

            return PartialView("Views/OrderPage/OrderPage.cshtml", shopCart);
        }

		[HttpGet]
		public IActionResult AdminOrderPage()
		{
			var customer = content.Customers.ToArray();
			List<AdminPagesViewModel> adminPages = new List<AdminPagesViewModel>();

            int customerLength = customer.Count();
            for (int i = 0; i < customerLength; i++)
            {
				ShopCart[] shopCart = content.ShopCarts.Where(x => x.CustomerId == customer[i].id).ToArray();

				int shopCartCount = shopCart.Count();
                if (shopCartCount == 0) continue;

				for (int j = 0; j < shopCartCount; j++)
				{
					shopCart[j].items = content.ShopCartItems.Where(x => x.ShopCartId == shopCart[j].Id).ToList();
				}

                adminPages.Add(new AdminPagesViewModel
                {
                    customer = customer[i],
                    carts = shopCart
                });
			}
			
			return PartialView("Views/OrderPage/AdminOrderPage.cshtml", adminPages);
		}

        [HttpGet]
        public IActionResult AdminPage() 
        {
			var auth = content.ClientAuths.Where(x => x.usertype == "admin").ToArray();
			List<AdminPagesViewModel> adminPages = new List<AdminPagesViewModel>();

			int authLength = auth.Count();
			for (int i = 0; i < authLength; i++)
			{
                Customer customer = content.Customers.First(x => x.authId == auth[i].id);

				adminPages.Add(new AdminPagesViewModel
				{
					customer = customer,
					auth = auth[i]
				});
			}

            Debug.WriteLine(authLength);

			return PartialView("Views/AdminPage/AdminPage.cshtml", adminPages);
		}
	}
}
