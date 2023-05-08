using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controllers.Session
{
    public class EndSessionController : Controller
    {
        [HttpPost]
        public IActionResult End()
        {
            Debug.WriteLine("***dell");
            string path = $"D:\\Fork\\ShoesShop\\Shop\\TempData\\{Request.Cookies["UserId"]}.dat";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return Json(new { success = true });
        }
    }
}
