using _01.MVCIntroDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _01.MVCIntroDemo.Controllers
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
			ViewBag.Message = "Hello world"!;
			return View();
		}
		[HttpGet]
		public IActionResult NumbersToN()
		{
			ViewBag.Count = 10;
			return View();
		}

		[HttpPost]
		public IActionResult NumbersToN(int count)
		{
			if (count > 0)
			{
				ViewBag.Count = count;
			}
			return View();
		}

		public IActionResult Numbers()
		{
			return View();
		}
		public IActionResult About()
		{
			ViewBag.Message = "This is an ASP.NET Core MVC app.";
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