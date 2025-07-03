using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Products")]
    public class DeleteProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteProductController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        // [HttpGet("Delete/{id}")]
        // public IActionResult DeleteProduct(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         var ProductItem = _productRepository.GetProductById(id.Value);
        //         if (ProductItem == null)
        //         {
        //             return NotFound();
        //         }
        //         return View(ProductItem);
        //     }
        // }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(product.ImageName))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages", product.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

            }
            _productRepository.DeleteProduct(product);
            await _productRepository.SaveAsync();

            return RedirectToAction("GetAllProducts", "GetProduct");
        }
    }
}