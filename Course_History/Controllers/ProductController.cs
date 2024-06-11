using Course_History.Models;
using Course_History.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Course_History.Controllers
{
	public class ProductController : Controller
	{
        private readonly DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Details(int Id)
		{
			if (Id == null) { return RedirectToAction("Index"); }
			var product = await _dataContext.Product
									 .Include(p => p.Category)
									 .FirstOrDefaultAsync(p => p.Id == Id);
			return View(product);
		}

		public async Task<IActionResult> SearchTitle(int Title)
		{
			var productByCategory = _dataContext.Product.Where(category => category.Title == Title);
			return View(await productByCategory.OrderByDescending(c => c.Id).ToListAsync());
		}
	}
}
