using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controller
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string? UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
    [Route("/Login")]
    public class LoginController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly LoginService loginRepository;

        public LoginController(UserService userService)
        {
            loginRepository = new LoginService(userService);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

			if (ModelState.IsValid)
            {
                if (loginRepository.IsExistUser(model.UserName, model.Password))
                {
                    var user = loginRepository.LogUserService(model.UserName, model.Password); 
                    var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, user.UserName),
						new Claim(ClaimTypes.Role , user.Role),
					    new Claim(ClaimTypes.Email , user.Email),
					};

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    bool IsPersistent = model.RememberMe;
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
                    Response.Cookies.Append("username" , model.UserName);
					ModelState.AddModelError("success", "نام کاربری یا رمز عبور اشتباه است.");
					return Redirect("/");
                }
                else
                {
	                ModelState.AddModelError("UserName", "نام کاربری یا رمز عبور اشتباه است.");
				}
			}
	        return Redirect("/Login");

		}


	}


}
