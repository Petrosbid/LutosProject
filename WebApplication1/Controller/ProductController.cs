using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ProductService ProductService { get; }

        public ProductController(ProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Myproducts> Get()
        {
            return ProductService.GetProducts();
        }

        //[Route("/Rate")]
        //[HttpGet]
        //public ActionResult Get([FromQuery] string Id, [FromQuery] int Rating)
        //{
        //    ProductService.AddRate(Id, Rating);
        //    return Ok();
        //}

    }
   }