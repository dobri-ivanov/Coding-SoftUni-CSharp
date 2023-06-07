using _01.MVCIntroDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01.MVCIntroDemo.Controllers
{
	public class ProductController : Controller
	{
		private IEnumerable<ProductViewModel> products = new HashSet<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Test",
				Price = 1
			},
			new ProductViewModel()
			{
				Id= 2,
				Name = "Dobri",
				Price= 2
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Test3",
				Price= 3
			}
		};

		public IActionResult All()
		{
			return View(products);
		}
		public IActionResult Index()
		{
			
			return View(products);
		}
	}
}
