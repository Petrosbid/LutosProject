using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.product;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public ProductService productService;
		public IEnumerable<Myproducts>? Products { get; private set; }
		public ILogger<IndexModel>? Logger => _logger;
        public IEnumerable<Myproducts>? SlideProducts { get; private set; }
        public Myproducts? SelectedProduct;
        public string? selectedProductId;


        public IndexModel(ILogger<IndexModel> logger, ProductService productService)
		{
			_logger = logger;
			this.productService = productService;
			SlideShow();
            CategorizeProducts();
			

		}
        public IEnumerable<Myproducts>? CategoryProducts { get; private set; } = new List<Myproducts>();

		public void CategorizeProducts()
        {
            var products = productService.GetProducts();

            var categorizedProducts = products.GroupBy(p => p.Category);

            CategoryProducts = categorizedProducts.Select(group => new Myproducts
            {
                Category = group.Key,
                Productid = group.ToList().ToString()
            }).ToList();

		}
		public IEnumerable<Myproducts>? CategorySelectProducts { get; private set; }
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
			SelectedProduct = productService.GetProducts().First(x => x.Productid == productId);
		}
        public void SlideShow()
        {
            SlideProducts = productService.GetProducts().Where(x => x.Slider == true).ToList();
        }
        public void OnGet()
		{
			Products = productService.GetProducts();
		}
	}

}