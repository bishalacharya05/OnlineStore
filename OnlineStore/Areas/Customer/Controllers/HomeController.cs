using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.DataAcess.Repository;
using OnlineStore.DataAcess.Repository.IRepository;
using OnlineStore.Models;

namespace OnlineStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {

            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productsList= _unitOfWork.Product.GetAll(includProperties: "Category").ToList();
            return View(productsList);
        }
        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork.Product.Get(u =>u.ProductId == productId,includProperties: "Category");
            return View(product);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
