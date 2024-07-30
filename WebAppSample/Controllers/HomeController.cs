using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WebAppSample.Models;

namespace WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyConnectionStrings _connectionStrings;

        public HomeController(ILogger<HomeController> logger, IOptions<MyConnectionStrings> myConnectionStrings)
        {
            _logger = logger;
            _connectionStrings = myConnectionStrings.Value;
        }

        public IActionResult Index()
        {
            ViewBag.MySqlString = _connectionStrings.MYSQLCONNSTR_mysquielconst;
            Trace.TraceError("Trace Error: Starting Application");
            Trace.TraceInformation("Trace Info: Starting Application");
            Trace.TraceWarning("Trace Warning: Starting Application");
            _logger.LogInformation("Info: Starting Application");
            _logger.LogWarning("Warning: Starting Application");
            _logger.LogError("Error: Starting Application");
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
    }
}