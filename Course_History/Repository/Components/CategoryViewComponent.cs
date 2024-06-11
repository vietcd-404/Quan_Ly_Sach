using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Course_History.Repository.Components
{
    public class CategoryViewComponent : ViewComponent
    {
		private readonly DataContext _context;

		public CategoryViewComponent(DataContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categories = await _context.Category.ToListAsync();
			return View(categories);
		}
	}
}
