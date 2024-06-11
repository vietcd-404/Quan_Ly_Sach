using Microsoft.AspNetCore.Mvc;

namespace Course_History.Controllers
{
	public class LoginController: Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Đoạn này cần thực hiện kiểm tra username và password với cơ sở dữ liệu hoặc bất kỳ cách xác thực nào bạn đang sử dụng

            // Giả sử đã xác thực và lấy được vai trò của người dùng từ cơ sở dữ liệu
            var role = "admin"; // hoặc "User", tùy thuộc vào kết quả xác thực

            if (role != null && role.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            else if (role != null && role.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("Index", "Home"); // Điều hướng người dùng đã đăng nhập nhưng không phải admin tới trang Home
            }
            else
            {
                return Forbid();
            }
        }
    }
	
}
