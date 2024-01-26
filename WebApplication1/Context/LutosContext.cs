using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
	public class LutosContext : DbContext
	{

		public LutosContext(DbContextOptions<LutosContext> options):base(options)
		{
		}
		
		public DbSet<MyUsers> UserContext { get; set; }
		public DbSet<Myproducts> ProductContext { get; set; }
		public DbSet<ProductComments> ProductComments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MyUsers>().ToTable("Users_Info");
			modelBuilder.Entity<Myproducts>().ToTable("Products_Info");
			modelBuilder.Entity<ProductComments>().ToTable("Product_Comments");

		}
	}
}
