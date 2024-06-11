using Course_History.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_History.Repository
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<CategoryModel> Category { get; set; }
		public DbSet<ProductModel> Product { get; set; }

		public DbSet<CartModel>	Cart { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
