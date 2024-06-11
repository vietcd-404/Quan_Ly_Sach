using Course_History.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Course_History.Models;

namespace Course_History.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		
		private readonly DataContext _dataContext;

		private readonly IWebHostEnvironment _webHostEnvironment;
		public ProductController(DataContext dataContext, IWebHostEnvironment webHostEnvironment) {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Product.OrderByDescending(p => p.Id).Include(p => p.Category).ToListAsync());
		}

		[HttpGet]
		public IActionResult Create() {
			ViewBag.Category = new SelectList(_dataContext.Category, "Id", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductModel productModel) {
            ViewBag.Category = new SelectList(_dataContext.Category, "Id", "Name", productModel.CategoryId);
			if (ModelState.IsValid) {
				/*productModel.Name = productModel.Name.Replace(" ","-");*/
				var ten = await _dataContext.Product.FirstOrDefaultAsync(p => p.Name == productModel.Name.Trim());
				if (ten != null) {
					ModelState.AddModelError("", "Sản phẩm đã tồn tại");
					return View(productModel);
				}
				
					if(productModel.ImageUpload != null)
					{
						string uploadSrt = Path.Combine(_webHostEnvironment.WebRootPath,"image");
						string imageName = Guid.NewGuid().ToString() + "_" + productModel.ImageUpload.FileName;
						string imagePath = Path.Combine(uploadSrt, imageName);
						FileStream file = new FileStream(imagePath, FileMode.Create);
						await productModel.ImageUpload.CopyToAsync(file);
						file.Close();
						productModel.Image = imageName;
					}
				/*return View(productModel); */

				
				_dataContext.Add(productModel);
				await _dataContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			else
			{
				List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var item in value.Errors)
                    {
                        errors.Add(item.ErrorMessage);
                    }
                }
				string message = string.Join(", ", errors);
				return BadRequest(message);
            }
			/*return View(productModel);*/
        }

		[HttpGet]
        public async Task<IActionResult> Edit(int Id)
		{
			ProductModel product = await _dataContext.Product.FindAsync(Id);
            ViewBag.Category = new SelectList(_dataContext.Category, "Id", "Name", product.CategoryId	);
			return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, ProductModel productModel)
        {
            ViewBag.Category = new SelectList(_dataContext.Category, "Id", "Name", productModel.CategoryId);
            if (ModelState.IsValid)
            {
                /*productModel.Name = productModel.Name.Replace(" ","-");*/
                var ten = await _dataContext.Product.FirstOrDefaultAsync(p => p.Name == productModel.Name.Trim());
            
                if (ten != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã tồn tại");
                    return View(productModel);
                }

                if (productModel.ImageUpload != null)
                {
                    string uploadSrt = Path.Combine(_webHostEnvironment.WebRootPath, "image");
                    string imageName = Guid.NewGuid().ToString() + "_" + productModel.ImageUpload.FileName;
                    string imagePath = Path.Combine(uploadSrt, imageName);
                    FileStream file = new FileStream(imagePath, FileMode.Create);
                    await productModel.ImageUpload.CopyToAsync(file);
                    file.Close();
                    productModel.Image = imageName;
                }
                /*return View(productModel); */


                _dataContext.Update(productModel);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var item in value.Errors)
                    {
                        errors.Add(item.ErrorMessage);
                    }
                }
                string message = string.Join(", ", errors);
                return BadRequest(message);
            }
            /*return View(productModel);*/
        }

        public async Task<IActionResult> Delete(int Id)
        {
            ProductModel product = await _dataContext.Product.FindAsync(Id);
            if (!string.Equals(product.Image, "noimage.jpg"))
            {
                string uploadSrt = Path.Combine(_webHostEnvironment.WebRootPath, "image");
                string imagePath = Path.Combine(uploadSrt, product.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            _dataContext.Product.Remove(product);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
