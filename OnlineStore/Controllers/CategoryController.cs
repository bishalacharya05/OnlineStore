using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAcess.Data;
using OnlineStore.DataAcess.Repository;
using OnlineStore.DataAcess.Repository.IRepository;
using OnlineStore.Models;
namespace OnlineStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
     //this method reterive the data of category table from the database.
     //ToList() bring the record of the data from the category table and make list.
     //this index action shows the list of category List
        public IActionResult Index()
        {
            List<Category> objCategoryList= _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //This checks if CategoryName and DisplayOrder are same or not.....
            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CategoryName","Name and DisplayOrder cannot be same");
            }
            //this checks if create the input field is valid or not....
            //if valid then only save the data to the category list...
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        //this action is to edit the category details ...
        public IActionResult Edit(int? id)
        {
            //this condition check if the id isvalid or not....
            if(id==null || id == 0)
            {
                return NotFound();
            }
            //this reterive the category id from the database
            Category? categoryFromDb = _unitOfWork.Category.Get(u=>u.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //this checks if create the input field is valid or not....
            //if valid then only Update the data to the category list...
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated sucessfully";
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete") ]

        public IActionResult DeletePost(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted sucessfully";
            return RedirectToAction("Index");
            
            
        }
    }
}
