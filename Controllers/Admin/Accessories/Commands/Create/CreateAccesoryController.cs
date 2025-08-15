using System.Security.AccessControl;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Accesories")]
    public class CreateAccesoryController : Controller
    {
        private readonly ProductService<Pocket> _accesoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateAccesoryController(ProductService<Pocket> accesoryService, IWebHostEnvironment webHostEnvironment)
        {
            _accesoryService = accesoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Create")]
        public IActionResult CreateAccesory()
        {
            return View();
        }
    }
}