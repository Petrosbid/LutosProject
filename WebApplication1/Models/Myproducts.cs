
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Myproducts
    {
        [Key]
	    public int ProductID { get; set; }
	    [Display(Name = "موجود")]
	    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
	    [MaxLength(150)]
		public bool? Available { get; set; }
	    [Display(Name = "کتگوری")]
		[AllowNull]
	    [MaxLength(150)]
		public string? Category { get; set; }
	    [Display(Name = "رنگ")]
		[AllowNull]
		[MaxLength(50)]
		public string? Color { get; set; }
        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(500)]
        public string? Main_Image { get; set; }
        [Display(Name = "توضیحات محصول")]
		[AllowNull]
		[MaxLength(500)]
		public string? ProductDescription { get; set; }
        [Display(Name = "تعداد لایک ها")]
		public int? Liked { get; set; } = 0;
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50)]
		public string? ProductName { get; set; }
        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(50)]
		public string? ProductPrice { get; set; }

		[Display(Name = "اسلایدر بودن محصول")] 
		public bool? Slider { get; set; } = false;

		public virtual List<ProductComments> ProductComments { get; set; }

	}
}