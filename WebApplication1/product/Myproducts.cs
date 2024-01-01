using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.product
{
	public class Myproducts
	{
		public bool? Available { get; set; }
		public string[]? Buyed { get; set; }
		public string? Category { get; set; }
        public string? Color { get; set; }
		public string[]? Comments { get; set; }
        public string? Main_Image { get; set; }
        public string? ProductDescription { get; set; }
		public int? IdTag { get; set; }
		public string[]? Images { get; set; }
		public string[]? Liked { get; set; }
		public string? ProductName { get; set; }
		public string? ProductPrice { get; set; }
		public string? Productid { get; set; }
		public int[]? Rating { get; set; }
		public bool? Slider {  get; set; }
		public string[]? Tags { get; set; }


		public override string ToString() => JsonSerializer.Serialize<Myproducts>(this);

	}
}
