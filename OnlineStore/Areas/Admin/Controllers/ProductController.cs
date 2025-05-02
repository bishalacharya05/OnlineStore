using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAcess.Data;
using OnlineStore.DataAcess.Repository;
using OnlineStore.DataAcess.Repository.IRepository;
using OnlineStore.Models;
namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //this method reterive the data of category table from the database.
        //ToList() bring the record of the data from the category table and make list.
        //this index action shows the list of category List
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            //this checks if create the input field is valid or not....
            //if valid then only save the data to the category list...
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        //this action is to edit the category details ...
        public IActionResult Edit(int? id)
        {
            //this condition check if the id isvalid or not....
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //this reterive the category id from the database
            Product? productFromDb = _unitOfWork.Product.Get(u => u.ProductId == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            //this checks if create the input field is valid or not....
            //if valid then only Update the data to the category list...
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            //this condition check if the id isvalid or not....
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //this delete/remove the category data from the database base on their id....
            Product? categoryFromDb = _unitOfWork.Product.Get(u => u.ProductId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.ProductId == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted sucessfully";
            return RedirectToAction("Index");
        }
    }
}
