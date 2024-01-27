using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductService productService;
        public IEnumerable<Myproducts>? Products { get; private set; }
        /*
                public ILogger<IndexModel>? Logger => _logger;
                private readonly ILogger<IndexModel> _logger;
        */
        public IEnumerable<Myproducts>? SlideProducts { get; private set; }

        public Myproducts? SelectedProduct;
        public string? selectedProductId;


        public IndexModel( /*ILogger<IndexModel> logger, */ ProductService productService)
        {
            //_logger = logger;
            this.productService = productService;
            SlideShow();
            CategorizeProducts();
            GetPopularProducts();
        }
        public IEnumerable<Myproducts>? CategoryProducts { get; private set; } = new List<Myproducts>();

        public void CategorizeProducts()
        {
            var products = productService.GetProducts();

            var categorizedProducts = products.GroupBy(p => p.Category);

            CategoryProducts = categorizedProducts.Select(group => new Myproducts
            {
                Category = group.Key,
                ProductName = group.ToList().ToString()
            }).ToList();

        }
        public string? Image;
        public string SelectByCategory(string item)
        {

            Image = productService.GetProducts()
                .First(x => x.Category == item).Main_Image;
            if (Image != null)
            {
                return Image;
            }
            return "";
        }
        public void SelectProduct(string productId)
        {
            selectedProductId = productId;
            SelectedProduct = productService.GetProducts().First(x => x.ProductID == int.Parse(productId));
        }
        public void SlideShow()
        {
            SlideProducts = productService.GetProducts().Where(x => x.Slider == true).ToList();
        }
        public void OnGet()
        {
            Products = productService.GetProducts();
        }
		public IEnumerable<Myproducts>? PopularProducts { get; private set; }

		public void GetPopularProducts()
        {
            var products = productService.GetProducts();
			PopularProducts = products.OrderByDescending(p => p.Liked).Take(15).ToList();
            
        }

		public void AddingProducts()
		{
			Myproducts newproduct1 = new()
			{
				Available = true,
				Category = null,
				Color = null,
				Main_Image = "https://rozalinstore.com/wp-content/uploads/2022/10/roz6-compressed.jpg",
				ProductDescription = null,
				Liked = null,
				ProductName = "asda",
				ProductPrice = "21413",
				Slider = true,
				ProductComments = null,
			};
			productService.Addproduct(newproduct1);
			Myproducts newproduct2 = new()
			{
				Available = true,
				Category = null,
				Color = null,
				Main_Image = "https://rozalinstore.com/wp-content/uploads/2023/01/off-org-min2.jpg",
				ProductDescription = null,
				Liked = null,
				ProductName = "asda",
				ProductPrice = "13434 تومان",
				Slider = true,
				ProductComments = null,
			};
			productService.Addproduct(newproduct2);
			Myproducts newproduct3 = new()
			{
				Available = true,
				Category = null,
				Color = null,
				Main_Image = "https://rozalinstore.com/wp-content/uploads/2022/03/slide-1asli.jpg",
				ProductDescription = null,
				Liked = null,
				ProductName = "asda",
				ProductPrice = "13434 تومان",
				Slider = true,
				ProductComments = null,
			};
			productService.Addproduct(newproduct3);
			Myproducts newproduct4 = new()
			{
				Available = true,
				Category = null,
				Color = null,
				Main_Image = "https://rozalinstore.com/wp-content/uploads/2022/03/slide2222-Copy.jpg",
				ProductDescription = null,
				Liked = null,
				ProductName = "asda",
				ProductPrice = "13434 تومان",
				Slider = true,
				ProductComments = null,
			};
			productService.Addproduct(newproduct4);

		}
	}
}