using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Models;
using Shop.Models.Cart;
using Shop.Models.Interfaces;
using Shop.Models.Mocks;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContent content;

        public ProductController(AppDBContent dBContent) 
        {
            content = dBContent;
        }

        
        public IActionResult GetShopCart()
        {
            var list = new
            {
                UserId = Request.Cookies["UserId"],
            };
            return PartialView("Views/ShopCart/ShopCart.cshtml", list);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            var index = Request.Cookies["UserId"];
            string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{index}.dat";

            if (System.IO.File.Exists(path))
            {
                dynamic file = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path));
                ShopCart cart = JsonConvert.DeserializeObject<ShopCart>(file["ShopCart"].ToString());

                AddShopCartItem(cart);
            }
            else
            {
                ShopCart cart = new ShopCart();
                AddShopCartItem(cart);
            }

            return Content("ok");

            void AddShopCartItem(ShopCart cart)
            {
                string productImg = product.img.Split(',')[0];
                cart.Add(new ShopCartItem
                {
                    Name = product.name,
                    Price = product.price,
                    Img = productImg,
                    Quantity = 1,
                });

                try
                {
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(new
                    {
                        ShopCart = cart
                    }));
                }
                catch { }
            }
        }

        [HttpPost]
        public IActionResult RemoveProduct([FromBody] Product product)
        {
            var index = Request.Cookies["UserId"];
            string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{index}.dat";

            if (System.IO.File.Exists(path))
            {
                dynamic file = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path));
                ShopCart cart = JsonConvert.DeserializeObject<ShopCart>(file["ShopCart"].ToString());

                cart.Remove(new ShopCartItem
                {
                    Name = product.name,
                    Price = product.price,
                    Quantity = 1,
                });

                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(new
                {
                    ShopCart = cart
                }));
            }

            return Content("ok");
        }

        public ViewResult ShowPage(string category = default)
        {
            ViewBag.Title = "Main page";
            ProductViewModel productViewModel = new ProductViewModel();
            #region Set ProductViewModel
            if (category == default)
            {
                productViewModel.Products = content.Products;
            }
            else
            {
                int categoryId = (int)Enum.Parse<CategoryType>(category);

                productViewModel.Products = content.Products;
                productViewModel.Products = productViewModel.Products
                    .Where(x => JsonConvert.DeserializeObject<int[]>(x.categories)
                    .Contains(categoryId));
            }
            #endregion

            #region Get Customer Type
            string customerId = Request.Cookies["UserId"];
            int id = content.Customers.FirstOrDefault(x => x.customerId == customerId).authId;
            string type = content.ClientAuths.FirstOrDefault(x => x.id == id).usertype;
            #endregion

            CustomerViewModel customerViewModel = new CustomerViewModel(type);
            customerViewModel._Custmers = content.Customers;

            var list = new
            {
                Products = productViewModel,
                Customers = customerViewModel,
                UserId = Request.Cookies["UserId"],
            };

            return View(list);
        }
    }
}
