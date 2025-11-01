using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{

    [Route("Admin/Fixators")]
    public class GetFixatorController : Controller
    {
        private readonly ProductService<Fixator> _fixatorService;

        public GetFixatorController(ProductService<Fixator> fixatorService)
        {
            _fixatorService = fixatorService;
        }

        [HttpGet]
        public IActionResult GetAllFixators()
        {
            var fixators = _fixatorService.GetAllProducts();
            return View(fixators);
        }
    }
}