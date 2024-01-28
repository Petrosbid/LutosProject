using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Pages;
using WebApplication1.Services;

namespace WebApplication1.Controller
{
	public class CategoryProductsViewModel
	{
		public string Category { get; set; }
		public List<Myproducts> Products { get; set; }
		public bool sendLike(Myproducts pMyproducts)
		{
			pMyproducts.Liked++;
			return true;
		}
	}

	public class ProductsPageController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly ProductService _productRepository;

		public ProductsPageController(ProductService productRepository)
		{
			_productRepository = productRepository;
		}
		[HttpGet]
		
		public IActionResult Category([FromRoute] string category)
		{
			var categoryProducts = _productRepository.GetProducts().Where(x => x.Category == category).ToList();

			var viewModel = new CategoryProductsViewModel
			{
				Category = category,
				Products = categoryProducts
			};

			return View("ProductsPage", viewModel);
		}
	}
}