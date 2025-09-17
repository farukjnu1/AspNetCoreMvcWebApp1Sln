using AspNetCoreMvcWebApp1.Models;
using AspNetCoreMvcWebApp1.Models.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcWebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {
            try
            {
                var ctx = new AuthDbContext();
                var oTblUsers = ctx.TblUsers.Where(o => o.Username == collection["Username"].ToString() && o.UserPass == collection["UserPass"].ToString()).FirstOrDefault();
                if (oTblUsers != null)
                {
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Append("isLoggedIn", "1", option);
                    Response.Cookies.Append("Username", oTblUsers.Username, option);

                    return RedirectToAction("Index", "Product");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("isLoggedIn");
            Response.Cookies.Delete("Username");
            return RedirectToAction("Index", "Home");
        }
    }
}
