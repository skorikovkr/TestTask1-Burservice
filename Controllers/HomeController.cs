using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using TestTask1.Infrastructure;
using TestTask1.Models;

namespace TestTask1.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sort(SortInfoModel model)
        {
            var elements = new MyList<string>(model.Text.Split(",").Select(el => el.Trim()));
            ViewData["Initial"] = String.Join(", ", elements);
            switch (model.SortType)
            {
                case "reverse":
                    elements.Reverse();
                    break;
                case "asc":
                    elements.Sort();
                    break;
                case "desc":
                    elements.Sort(false);
                    break;
                default:
                    break;
            }
            ViewData["Sorted"] = String.Join(", ", elements);
            return this.View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}