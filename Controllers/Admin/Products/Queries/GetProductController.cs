

using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Products")]
    public class GetProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public GetProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var perfumes = _productRepository.GetAllProducts();
            return View(perfumes);
        }
    }
}