using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
