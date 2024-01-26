using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
	public class LoginModel : PageModel
	{
		public UserService UserService;
		public ILogger<LoginModel>? Logger { get; }

		public LoginModel(ILogger<LoginModel> logger, UserService UserService)
        {
            Logger = logger;
            this.UserService = UserService;
        }
       
    }
}
