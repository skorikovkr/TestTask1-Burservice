using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
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
        public async Task<IActionResult> Index(IList<IFormFile> files)
        {
            var file = files.FirstOrDefault();

            if (file == null) {
                return View("Error");
            }

            string filename = file.FileName;

            string result = "";
            using (StreamReader reader = new StreamReader(file.OpenReadStream())) { 
                result = await reader.ReadToEndAsync();
            }

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}