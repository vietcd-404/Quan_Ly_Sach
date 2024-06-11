using Course_History.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Course_History.Areas.Admin.Controllers
{ 
       [Area("Admin")]
public class OrderController : Controller
	{
 
    private readonly DataContext _dataContext;
		public OrderController(DataContext dataContext)
		{
			_dataContext = dataContext;
		
		}
		
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Orders.OrderByDescending(p => p.Id).ToListAsync());
		}


        public async Task<IActionResult> ViewOrder(string orderCode)
        {
            var details = await _dataContext.OrderDetails
                                   .Include(od => od.Product)
                                   .Where(od => od.OrderCode == orderCode)
                                   .ToListAsync();
            return View(details);
        }
    }
}
