using CalculatorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Calculator;

namespace CalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _webLogger;

        private Logger _logger;
        private SimpleCalculator _calculator;

        [HttpGet]
        public int Add(int start, int amount)
        {
            return _calculator.Add(start, amount);
        }

        [HttpGet]
        public int Subtract(int start, int amount)
        {
            return _calculator.Subtract(start, amount);
        }

        [HttpGet]
        public int Multiply(int start, int by)
        {
            return _calculator.Multiply(start, by);
        }

        [HttpGet]
        public float Divide(int start, int by)
        {
            return _calculator.Divide(start, by);
        }

        [HttpPost]
        public string Calculate()
        {
            return "Calculated";
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _webLogger = logger;
        }

        public IActionResult Index()
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