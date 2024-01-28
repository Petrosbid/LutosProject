using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class ProductsPageModel : PageModel
    {
	    private readonly ProductService productService;

	    public ProductsPageModel(ProductService productService)
	    {
		    this.productService = productService;

	    }


		public void OnGet()
        {
        }
    }
}
