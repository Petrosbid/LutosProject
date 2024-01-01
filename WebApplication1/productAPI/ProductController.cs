using Microsoft.AspNetCore.Mvc;
using WebApplication1.product;
using WebApplication1.Services;

namespace WebApplication1.productAPI
{
	[Route("[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		public ProductController(ProductService productService)
		{
			this.ProductService = productService;
		}
		public ProductService ProductService { get; }

		[HttpGet]
		public IEnumerable<Myproducts> Get()
		{
			return ProductService.GetProducts();
		}

		[Route("/Rate")]
		[HttpGet]
		public ActionResult Get([FromQuery] string Id, [FromQuery] int Rating)
		{
			ProductService.AddRate(Id, Rating);
			return Ok();
		}

	}
}
