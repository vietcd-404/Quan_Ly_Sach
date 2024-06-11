using Course_History.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_History.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Không bỏ thể loại")]
        public int CategoryId { get; set; }

		[Required(ErrorMessage = "Không bỏ trống tên sản phẩm ")]
		public string Name { get; set; }
		public int Status { get; set; }

        [Required(ErrorMessage = "Không bỏ trống giá tiền ")]
        public double Price { get; set; }

		public string Image { get; set; } = "noimage.jpg";

        [Required (ErrorMessage = "Không bỏ trống số lượng ")]

        public int Quantity { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Không bỏ danh mục")]
        public int Title { get; set; }

        public CategoryModel Category { get; set; }
		[NotMapped]
		[FileExtension]
        [Required(ErrorMessage = "Không bỏ trống ảnh ")]
        public IFormFile ImageUpload { get; set; }

	}
}
