using System;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Request.Cookies["id"]?.Value))
            {
                HttpContext.Response.Cookies["id"].Value = Guid.NewGuid().ToString();
            }
            
            return View();
        }
    }
}