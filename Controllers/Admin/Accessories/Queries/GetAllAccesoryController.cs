using System.Net.Http.Headers;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Accesories")]
    class GetAllAccesoryController : Controller
    {
        private readonly ProductService<Pocket> _accesoryService;

        public GetAllAccesoryController(ProductService<Pocket> accesoryService)
        {
            _accesoryService = accesoryService;
        }

        [HttpGet]
        public IActionResult GetAllAccesories()
        {
            var accesory = _accesoryService.GetAllProducts();
            return View(accesory);
        }
    }
}