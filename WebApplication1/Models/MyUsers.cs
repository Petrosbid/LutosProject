using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace WebApplication1.Models
{
    public class MyUsers
    {
	    [Key]
	    public int Id { get; set; }
		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(200)]
		public string Email { get; set; }
		[Display(Name = "رمز عبوور")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(15)]
        public string Password { get; set; }
		[Display(Name = "نقش")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(10)]
        public string Role { get; set; } = "user";
		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(15)]
        public string UserName { get; set; }
		[Display(Name = "اسم")]
		[AllowNull]
		[MaxLength(15)]
        public string? FirstName { get; set; }
        [Display(Name = "فامیل")]
        [AllowNull]
		[MaxLength(15)]
        public string? LastName { get; set; }
		[Display(Name = "نشانی")]
		[AllowNull]
		[MaxLength(60)]
        public string? Address { get; set; }
        [Display(Name = "کد پستی")]
		[AllowNull]
        [MaxLength(15)]
		public int? PostalCode { get; set; }
		[AllowNull]
		public virtual List<Myproducts> CartProducts { get; set; }
	}
}
