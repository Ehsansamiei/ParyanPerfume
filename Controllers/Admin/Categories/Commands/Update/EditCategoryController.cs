
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Categories")]
    public class EditCategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ParyanPerfumeDbContext _paryanPerfumeDbContext;

        public EditCategoryController(ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment, ParyanPerfumeDbContext paryanPerfumeDbContext)
        {
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
            _paryanPerfumeDbContext = paryanPerfumeDbContext;

        }
        [HttpGet("Edit/{id}")]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetCategoryById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            var dto = new CategoriesDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CategoryNickName = category.CategoryNickName,
                CategoryDescription = category.CategoryDescription,
                ImageName = category.ImageName
            };
            return View(dto);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> EditCategory(CategoriesDto Dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                // دیباگ یا لاگ
                Console.WriteLine("ModelState Errors: " + string.Join(" | ", errors));
                return View(Dto);
            }

            var category = await _paryanPerfumeDbContext.category.FindAsync(Dto.CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            category.CategoryName = Dto.CategoryName;
            category.CategoryNickName = Dto.CategoryNickName;
            category.CategoryDescription = Dto.CategoryDescription;

            // اگر عکس جدید نیومده، عکس قبلی رو نگه دار
            if (Dto.ImageFile == null && !string.IsNullOrEmpty(Dto.ImageName))
            {
                category.ImageName = Dto.ImageName;
            }


            if (Dto.ImageFile != null)
            {
                // حذف عکس قبلی و آپلود جدید
                if (!string.IsNullOrEmpty(category.ImageName))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryImages", category.ImageName);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(Dto.ImageFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryImages");

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                var newPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await Dto.ImageFile.CopyToAsync(stream);
                }

                category.ImageName = fileName;
            }


            await _paryanPerfumeDbContext.SaveChangesAsync();

            return RedirectToAction("GetAllCategories", "GetCategory");
        }

    }
}