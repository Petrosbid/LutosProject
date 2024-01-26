using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class LoginService 
    {
        private readonly UserService DbUserService;

        public LoginService(UserService dbUserService)
        {
            DbUserService = dbUserService;
        }
        public bool IsExistUser(string UserName, string Password)
        {
           return  DbUserService.GetUser().Any(x => x.UserName == UserName && x.Password == Password);
        }
        public bool IsExistUser(string UserName)
        {
	        return DbUserService.GetUser().Any(x => x.UserName == UserName);
        }

		public MyUsers LogUserService(string UserName, string Password)
        {
            return DbUserService.GetUser().First(x => x.UserName == UserName && x.Password == Password);
        }
        public void CreateUser(string UserName, string Password , string Email)
        {
	        MyUsers newUser = new() { UserName = UserName, Password = Password, Address = null, CartProducts = null, Email = Email, FirstName =null , LastName = null, PostalCode =null , Role = "userName"};
            DbUserService.AddUser(newUser);
        }
	}
}
