using kv_yr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kv_yr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task Index()
        {
            string content = @"<form method='post'>
                <label>Введите a:</label><br />
                <input type='number' name='a' /><br />
                <label>Введите b:</label><br />
                <input type='number' name='b' /><br />
                <label>Введите c:</label><br />
                <input type='number' name='c' /><br />
                <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(content);

        }
        [HttpPost]
        public string Index(double a, double b, double c)
        {
            double discriminant = Math.Pow(-b, 2) - 4 * a * c;

            string result = "";

            if (discriminant < 0)
            {
                result = $"Нет результатов {discriminant}";
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                result = $"Есть один корень: {root}";
            }
            else
            {
                double root1 = Math.Round((-b + Math.Sqrt(discriminant)) / (2 * a),2);
                double root2 = Math.Round((-b - Math.Sqrt(discriminant)) / (2 * a),2);
                result = $"Есть два корня: первый равен: {root1}, второй равен: {root2}";

            }
            return result;
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

    }
}