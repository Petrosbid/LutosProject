using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
	public class LoginModel : PageModel
	{
		public ILogger<LoginModel>? Logger { get; }


		public LoginModel(ILogger<LoginModel> logger)
        {
            Logger = logger;
        }
    }
}