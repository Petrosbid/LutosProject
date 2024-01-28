using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
	public class ShoppingCartModel : PageModel
	{
		private readonly UserService userService;

		public ShoppingCartModel( /*ILogger<IndexModel> logger, */ UserService usersService )
		{
			this.userService = usersService;
			Cart();
		}

		public MyUsers FindUser()
		{
			var uservname = HttpContext.Request.Cookies["username"];

				return userService.GetUser().First(x => x.UserName == uservname);
		}
		public IEnumerable<Myproducts> Cart()
		{
			if (FindUser() != null)
			{
				var user = FindUser();
				return user.CartProducts;
			}

			return null;
		}
		public bool DeleteItem(Myproducts product, MyUsers user)
		{
			if (product != null && user != null)
			{
				user.CartProducts.Remove(product);
				return true;
			}

			return false;
		}
		public void OnGet()
		{

		}
	}
}
