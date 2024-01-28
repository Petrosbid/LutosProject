using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controller
{
    [Route("/Cart")]
    public class CartController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet]
        public void DeleteItem(Myproducts product, MyUsers user)
        {
            user.CartProducts.Remove(product);
        }
    }
}
