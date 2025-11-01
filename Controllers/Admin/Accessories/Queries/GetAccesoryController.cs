using System.Net.Http.Headers;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Accesories")]
    public class GetAccesoryController : Controller
    {
        private readonly ProductService<Pocket> _accesoryService;

        public GetAccesoryController(ProductService<Pocket> accesoryService)
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