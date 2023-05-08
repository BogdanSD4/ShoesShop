using Microsoft.AspNetCore.Mvc;
using Shop.Database;
using System.IO;
using Shop.Models.Mocks;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDBContent _content;
        public LoginController(AppDBContent dBContent)
        {
            _content = dBContent;
        }
        [HttpPost]
        public JsonResult CheckLogin(string username, string password)
        {
            string message = "";
            bool result = CheckLoginAndPassword(username, password);

            return Json(new { success = result, message = message });

            bool CheckLoginAndPassword(string username, string password)
            {
                var index = Request.Cookies["UserId"];
                string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{index}.dat";
                string type = System.IO.File.ReadAllText(path);
                
                var list = _content.ClientAuths.Where(x => x.usertype == type);

                foreach (var auth in list)
                {
                    if(auth.username == username)
                    {
                        if (auth.password == password)
                        {
                            var customer = _content.Customers.First(x => x.authId == auth.id);
                            customer.customerId = index;

                            System.IO.File.Delete(path);
                            _content.SaveChanges();
                            return true;
                        }
                        message = "Invalid password or login";
                        return false;
                    }
                }
                message = "This user is not registered";
                return false;
            }
        }
        [HttpPost]
        public JsonResult CheckSignIn(string username, string password, string email)
        {
            string message = "";
            bool result = CheckLoginAndPassword();

            return Json(new { success = result, message = message });

            bool CheckLoginAndPassword()
            {
                string invalidChar = "./,\\*-+=)]}&^%$#@!'\"";

                #region Check Username
                if (username == null || username.Length < 4 || username.Length > 20)
                {
                    message = "Invalid username";
                    return false;
                }
                for (int i = 0; i < username.Length; i++)
                {
                    if (invalidChar.Contains(username[i]))
                    {
                        message = "Username contains invalid characters";
                        return false;
                    }
                }
                #endregion
                #region Check Password
                if (password == null || password.Length < 4 || password.Length > 16)
                {
                    message = "Invalid username";
                    return false;
                }
                for (int i = 0; i < password.Length; i++)
                {
                    if (invalidChar.Contains(password[i]))
                    {
                        message = "Username contains invalid characters";
                        return false;
                    }
                }
                #endregion
                #region Check Email
                if (!email.Contains("@gmail.com"))
                {
                    message = "Invalid email";
                    return false;
                }
                #endregion

                foreach (var client in _content.ClientAuths)
                {
                    if (client.username == username)
                    {
                        message = "Username is taken";
                        return false;
                    }
                }

                var identificator = Request.Cookies["UserId"];
                string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{identificator}.dat";
                string type = System.IO.File.ReadAllText(path);

                int id = 1;
                if (_content.ClientAuths != null && _content.ClientAuths.Count() > 0)
                {
                    id = _content.ClientAuths.Max(client => client.id) + 1;
                }
                _content.ClientAuths.Add(new Models.ClientAuth { 
                    id = id, 
                    username = username, 
                    password = password, 
                    registrationTime = DateTime.Now, 
                    usertype = type});
                _content.Customers.Add(new Models.Customer { 
                    authId = id, 
                    customerId = identificator, 
                    email = email});
                _content.SaveChanges();

                return true;
            }
        }
        [HttpPost]
        public JsonResult SaveClientType(string type)
        {
            string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{Request.Cookies["UserId"]}.dat";
            System.IO.File.WriteAllText(path, type);

            return Json(new { success = true });
        }

        public ViewResult Login()
        {
            ViewBag.Title = "Login";

            return View();
        }
        public ViewResult SignIn()
        {
            ViewBag.Title = "SignIn";

            return View();
        }
        public ViewResult Workspace()
        {
            var userId = Guid.NewGuid().ToString();
            Response.Cookies.Append("UserId", userId);

            ViewData["UserId"] = userId;

            ViewBag.Title = "Workspace";

            return View();
        }
    }
}
