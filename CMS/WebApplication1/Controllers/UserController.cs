using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            var user = new User();
            using (Model1Container context = new Model1Container())
            {
                user = context.Users.Where(a => a.username == lvm.username && a.password == lvm.password).FirstOrDefault();
            }

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password!");
                return View();
            } else
            {
                ModelState.AddModelError("", "Successful");
                return RedirectToAction("../Schedule/Index");
                //("Index = Page", "Home = Controller")
            }
        }
    }
}