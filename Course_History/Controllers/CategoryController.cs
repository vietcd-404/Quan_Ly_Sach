using Course_History.Models;
using Course_History.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_History.Controllers
{
	public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;
		public CategoryController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<IActionResult> Index(int Id)
		{
			/*CategoryModel category = _dataContext.Category.Where(c => c.Id == Id).FirstOrDefault();*/

			var productByCategory = _dataContext.Product.Where(category => category.CategoryId == Id);
			return View(await productByCategory.OrderByDescending( c => c.Id).ToListAsync());
		}
	}
}
