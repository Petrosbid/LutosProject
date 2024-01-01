using System.Text.Json;
using WebApplication1.product;

namespace WebApplication1.Services
{
	public class ProductService
	{
		public ProductService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		public IWebHostEnvironment WebHostEnvironment { get; }

		private string JsnFile => Path.Combine(WebHostEnvironment.WebRootPath, "data", "Products.json");

		public IEnumerable<Myproducts> GetProducts()
		{
			using var jsonFileReader = File.OpenText(JsnFile);

			var setting = JsonSerializer.Deserialize<Myproducts[]>(jsonFileReader.ReadToEnd(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
			if (setting != null) { return setting; }
			else { return Enumerable.Empty<Myproducts>(); }

		}
		public void AddRate(string Id, int Rate)
		{
			IEnumerable<Myproducts> products = GetProducts();
			var query = products.First(x => x.Productid == Id);
			if (query.Rating == null)
			{
				query.Rating = new int[] { Rate };
			}
			else
			{
				var rating = query.Rating.ToList();
				rating.Add(Rate);
				query.Rating = rating.ToArray();
			}
			using var outputstream = File.OpenWrite(JsnFile);
			JsonSerializer.Serialize<IEnumerable<Myproducts>>(
				new Utf8JsonWriter(outputstream, new JsonWriterOptions
				{
					SkipValidation = true,
					Indented = true
				}),
				products);

		}


	}
}
