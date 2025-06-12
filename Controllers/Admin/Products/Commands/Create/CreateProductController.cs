

using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin{
    [Route("Admin/Products")]

    public class CreateProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateProductController(ICategoryRepository categoryRepository, IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
            _productRepository = productRepository;
        }


        [HttpGet("Create")]
        public IActionResult CreateProduct()
        {
            ViewBag.CategoryId = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductsDto productsDto)
        {
            if (ModelState.IsValid)
            {
                var product = new Products
                {
                    ProductId = productsDto.ProductId,
                    CategoryId = productsDto.CategoryId,
                    ProductName = productsDto.ProductName,
                    ProductNickName = productsDto.ProductNickName,
                    ProductDescription = productsDto.ProductDescription,
                    ProductBrand = productsDto.ProductBrand,
                    ProductSex = productsDto.ProductSex,
                    Price = productsDto.Price,
                    PricePer100gram = productsDto.Price,
                    ShortDescription = productsDto.ShortDescription,
                    CreateDate = DateTime.Now,
                    LastModified = DateTime.Now
                };

                if (productsDto.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(productsDto.ImageFile.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string filePath2 = Path.Combine(filePath, fileName);
                    using (var filestream = new FileStream(filePath2, FileMode.Create))
                    {
                        await productsDto.ImageFile.CopyToAsync(filestream);
                    }
                    product.ImageName = fileName;
                }
                product.category = _categoryRepository.GetCategoryById(productsDto.CategoryId);
                _productRepository.InsertProduct(product);
                var result = await _productRepository.SaveAsync();

                Console.WriteLine($"saved : {result}");
            }
            else
            {
                Console.WriteLine("ModelState is invalid");
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Error in {modelState.Key}: {error.ErrorMessage}");
                    }
                }
            }
            return RedirectToAction("GetAllProducts", "GetProduct");
        }
    }
}