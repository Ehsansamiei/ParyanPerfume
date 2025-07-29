
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Categories")]
    public class DeleteCategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPerfumeRepository _perfumeRepository;


        public DeleteCategoryController(ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment, IPerfumeRepository perfumeRepository)
        {
            _perfumeRepository = perfumeRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet("Delete/{id}")]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var categoryItem = _categoryRepository.GetCategoryById(id.Value);
                if (categoryItem == null)
                {
                    return NotFound();
                }
                var products = _perfumeRepository.GetPerfumesByCategoryId(id.Value);
                ViewBag.ProdcutsInCategory = products;
                return View(categoryItem);
            }
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var products = _perfumeRepository.GetPerfumesByCategoryId(id); 

            if (products.Any())
            {
                TempData["ErrorMessage"] = "تا زمانی که محصولات مرتبط با این دسته‌بندی وجود دارند، حذف امکان‌پذیر نیست.";
                return RedirectToAction("DeleteCategory", new { id });
            }

            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            { 
                return NotFound();
            }

            // حذف تصویر
            if (!string.IsNullOrEmpty(category.ImageName))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryImages", category.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                    
                }
            }

            _categoryRepository.DeleteCategory(category);
            await _categoryRepository.SaveAsync();

            return RedirectToAction("GetAllCategories", "GetCategory");
        }


    }
}