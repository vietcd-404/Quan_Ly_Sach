using Course_History.Models;
using Course_History.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_History.Controllers
{
	public class AccountController : Controller
	{

		private static List<UserModel> users = new List<UserModel>
	{
		new UserModel { Id = 1, Username = "admin", Password = "123", Role = "admin"},
		new UserModel { Id = 2, Username = "user", Password = "123", Role = "user" },
		new UserModel { Id = 3, Username = "user1", Password = "123", Role = "user" },
		new UserModel { Id = 4, Username = "user2", Password = "123", Role = "user" },
	};
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Username and password are required.";
                return RedirectToAction("Index");
            }
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", user.Role);
                if (user.Role == "admin")
                {
                    return RedirectToAction("Index", "Product", new { area = "Admin" });
                }
                else if (user.Role == "user")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Nếu có các vai trò khác, bạn có thể xử lý tại đây
                    return RedirectToAction("Index", "Home"); // Điều hướng mặc định nếu không có vai trò nào được xác định
                }
            }
            else
            {
                ViewBag.Error = "Invalid login attempt.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account");
        }

    }
}
