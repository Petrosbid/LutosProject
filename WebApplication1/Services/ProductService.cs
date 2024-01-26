using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public class ProductService
	{
		private readonly LutosContext db;

		public ProductService(LutosContext context)
		{
			this.db = context;
		}
		public IEnumerable<Myproducts> GetProducts()
		{
			var setting = db.ProductContext;
			if (setting != null) { return setting; }
			else { return Enumerable.Empty<Myproducts>(); }

		}
		//public void AddRate(string Id, int Rate)
		//{
		//	IEnumerable<Myproducts> products = GetProducts();
  //          IEnumerable<Myproducts> myproductsEnumerable = products.ToList();
  //          var query = myproductsEnumerable.First(x => x.Productid == Id);
		//	if (query.Rating == null)
		//	{
		//		query.Rating = new int[] { Rate };
		//	}
		//	else
		//	{
		//		var rating = query.Rating.ToList();
		//		rating.Add(Rate);
		//		query.Rating = rating.ToArray();
		//	}
		//	using var outputstream = File.OpenWrite(JsnFile);
		//	JsonSerializer.Serialize(
		//		new Utf8JsonWriter(outputstream, new JsonWriterOptions
		//		{
		//			SkipValidation = true,
		//			Indented = true
		//		}),
		//		myproductsEnumerable);

		//}


	}
}
