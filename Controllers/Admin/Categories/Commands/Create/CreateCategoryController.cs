

using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Categories")]
    public class CreateCategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateCategoryController(ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet("Create")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(CategoriesDto categoriesDto)
        {
            Console.WriteLine(">>> POST action reached");

            if (ModelState.IsValid)
            {

                var category = new Category
                {
                    Id = categoriesDto.CategoryId,
                    Name = categoriesDto.CategoryName,
                    Description = categoriesDto.CategoryDescription
                };

                if (categoriesDto.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(categoriesDto.ImageFile.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryImages");

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string filePath2 = Path.Combine(filePath, fileName);
                    using (var filestream = new FileStream(filePath2, FileMode.Create))
                    {
                        await categoriesDto.ImageFile.CopyToAsync(filestream);
                    }
                    category.ImageName = fileName;
                }

                _categoryRepository.InsertCategory(category);
                var result = await _categoryRepository.SaveAsync();
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
            return RedirectToAction("GetAllCategories", "GetCategory");

        }
    }
}