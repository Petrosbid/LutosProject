using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class ProductComments
	{
		[Key]
		public int CommentID { get; set; }

		[Display(Name = "محصول")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public int ProductID { get; set; }

		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(150)]
		public string Name { get; set; }
		[Display(Name = "ایمیل")]
		[MaxLength(200)]
		public string Email { get; set; }

		[Display(Name = "نظر")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(500)]
		public string Comment { get; set; }

		[Display(Name = "تاریخ ثبت")]
		public DateTime CreateDate { get; set; }
	}
}
