

using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Categories")]
    public class GetCategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            return View(categories);
        }
    }
}