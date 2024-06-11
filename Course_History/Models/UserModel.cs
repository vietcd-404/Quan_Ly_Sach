using System.Data;

namespace Course_History.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; } // For simplicity, storing passwords as plain text (not recommended for production)
		public string Role { get; set; }
	}
}
