using System.ComponentModel.DataAnnotations;

namespace Course_History.Models
{
	public class CategoryModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Status { get; set; }

	}
}
