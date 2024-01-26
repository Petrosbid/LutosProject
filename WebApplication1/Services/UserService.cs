using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
	    private readonly LutosContext db;
		public UserService(LutosContext context)
		{
			db = context;
		}

		public IEnumerable<MyUsers> GetUser()
		{
			var setting = db.UserContext;
			if (setting != null) { return setting; }
			 return Enumerable.Empty<MyUsers>(); 
		}

		public void AddUser(MyUsers newUser)
		{
			db.UserContext.Add(newUser);
			db.SaveChanges();
		}

	}
}
