using DataLayer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;



namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Product")]
    public class EditProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditProductController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var dto = new ProductsDto
            {
                CategoryId = product.CategoryId,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductNickName = product.ProductNickName,
                Price = product.Price,
                PricePer100gram = product.PricePer100gram,
                ShortDescription = product.ShortDescription,
                ImageName = product.ImageName,
                ProductBrand = product.ProductBrand,
                ProductDescription = product.ProductDescription,
                ProductSex = product.ProductSex,
                ShowInSlider = product.ShowInSlider,
            };
            return View(dto);
        }
    }
}