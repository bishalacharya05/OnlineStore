using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using OnlineStore.DataAcess.Data;
using OnlineStore.DataAcess.Repository;
using OnlineStore.DataAcess.Repository.IRepository;
using OnlineStore.Models;
using OnlineStore.Models.ViewModel;
namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        //this method reterive the data of Product table from the database.
        //ToList() bring the record of the data from the product table and make list.
        //this index action shows the list of category List
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includProperties:"Category").ToList();

            return View(objProductList);
        }
        //In this we are combining the update or edit method and naming as Upsert
        public IActionResult Upsert(int? id)
        {


            ProductViewModel productViewModel = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString()

                }),

                Product = new Product()

            };
            //this is to create the product because while creatint the product we generate the new id and is id null at that time
            if (id == null || id == 0)
            {
                return View(productViewModel);
            }
            //this is to update or edit . We can to select any product to update so the id must not be null here
            else
            {
                productViewModel.Product = _unitOfWork.Product.Get(u => u.ProductId == id);
                return View(productViewModel);
            }
        }



        [HttpPost]
        public IActionResult Upsert(ProductViewModel productViewModel, IFormFile? file)
        {
            //this checks if create the input field is valid or not....
            //if valid then only save the data to the Product list...
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"image\product");

                    if (!string.IsNullOrEmpty(productViewModel.Product.ImageUrl))
                    {
                        //deleting old image to edit operation 
                        var oldImagePath = Path.Combine(wwwRootPath, productViewModel.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productViewModel.Product.ImageUrl = @"\image\product\" + fileName;

                }

                if (productViewModel.Product.ProductId == 0)
                {
                    _unitOfWork.Product.Add(productViewModel.Product);

                }
                else
                {
                    _unitOfWork.Product.Update(productViewModel.Product);
                }

                _unitOfWork.Save();
                TempData["success"] = "Product Created sucessfully";
                return RedirectToAction("Index");
            }
            else
            {

                productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString()

                });
            }


            return View(productViewModel);
        }

        public IActionResult Delete(int? id)
        {
            //this condition check if the id isvalid or not....
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //this delete/remove the category data from the database base on their id....
            Product? productFromDb = _unitOfWork.Product.Get(u => u.ProductId == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
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
