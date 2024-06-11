using Course_History.Models;
using Course_History.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Course_History.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DataContext _dataContext;

        public CheckoutController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ActionResult> Checkout() { 
            var ordercode = Guid.NewGuid().ToString();
            var orderItem = new Order();
            orderItem.OrderCode = ordercode;
            orderItem.UserName = HttpContext.Session.GetString("Username");
            orderItem.Status = 1;
            orderItem.CreatedDate = DateTime.Now;
           
            double total = 0;
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            foreach (var item in cartItems) { 
                var oderDetail = new OrderDetail();
                oderDetail.UserName = HttpContext.Session.GetString("Username");
                oderDetail.Quantity = item.Quantity;
                oderDetail.Price = item.Price;
                oderDetail.OrderCode = ordercode;
                oderDetail.ProductId = item.ProductId;
                 total += (item.Price * item.Quantity); 
                _dataContext.Add(oderDetail);
                _dataContext.SaveChanges();
            }
            orderItem.TotalMoney = total;
            _dataContext.Add(orderItem);
            _dataContext.SaveChanges();
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index", "Cart");
        }
    }
}
