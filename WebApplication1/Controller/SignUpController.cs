using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controller
{
	public class SignUpViewModel
	{
		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200)]
		public string UserName { get; set; }

		[Display(Name = "کلمه عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public bool RememberMe { get; set; }

	}

	[Route("/SignUp")]
	public class SignUpController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly LoginService loginRepository;

		public SignUpController(UserService userService)
		{
			loginRepository = new LoginService(userService);
		}
		[HttpPost]
		public async Task<ActionResult> Signup(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (!loginRepository.IsExistUser(model.UserName))
				{
					loginRepository.CreateUser(model.UserName, model.Password, model.Email);
					var user = loginRepository.LogUserService(model.UserName, model.Password);
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, user.UserName),
						new Claim(ClaimTypes.Role , user.Role),
						new Claim(ClaimTypes.Email , user.Email),
					};
					bool IsPersistent = model.RememberMe;
					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					await HttpContext.SignInAsync(
						CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(claimsIdentity),
						new AuthenticationProperties
						{
							IssuedUtc = DateTimeOffset.Now,
							IsPersistent = IsPersistent,
							ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
							AllowRefresh = true
						});
					TempData["Message"] = "ثبت نام موفقیت‌آمیز بود. لطفاً وارد شوید.";
					return Redirect("/");
				}
				else
				{
					ModelState.AddModelError("Username", "نام کاربری انتخاب شده در حال حاضر استفاده شده است.");
				}
			}
			return View();
		}
	}
}
