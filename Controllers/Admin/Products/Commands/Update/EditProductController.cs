using DataLayer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Products")]
    public class EditProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ParyanPerfumeDbContext _paryanPerfumeDbContext;

        public EditProductController(IProductRepository productRepository,  ParyanPerfumeDbContext paryanPerfumeDbContext, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
            _categoryRepository = categoryRepository;
            _paryanPerfumeDbContext = paryanPerfumeDbContext;
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

            ViewBag.CategoryId = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            return View(dto);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> EditProduct(ProductsDto Dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine("ModelState Errors: " + string.Join(" | ", errors));
                return View(Dto);
            }

            var product = _productRepository.GetProductById(Dto.ProductId);
            if (product == null)
            {
                return NotFound();
            }
            product.CategoryId = product.CategoryId;
            product.ProductId = product.ProductId;
            product.ProductName = product.ProductName;
            product.ProductNickName = product.ProductNickName;
            product.Price = product.Price;
            product.PricePer100gram = product.PricePer100gram;
            product.ShortDescription = product.ShortDescription;
            product.ImageName = product.ImageName;
            product.ProductBrand = product.ProductBrand;
            product.ProductDescription = product.ProductDescription;
            product.ProductSex = product.ProductSex;
            product.ShowInSlider = product.ShowInSlider;

            if (Dto.ImageFile == null && !string.IsNullOrEmpty(Dto.ImageName)) {
                product.ImageName = Dto.ImageName;
            }

            if (Dto.ImageFile != null) {
                if (!string.IsNullOrEmpty(product.ImageName))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages", product.ImageName);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(Dto.ImageFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var newPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await Dto.ImageFile.CopyToAsync(stream);
                }
                product.ImageName = fileName;
            }

            await _productRepository.SaveAsync();
            return RedirectToAction("GetAllProducts", "GetProdcut");
        }
    }
}