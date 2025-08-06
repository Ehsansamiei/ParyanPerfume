using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Bottles")]
    public class CreateBottleController : Controller
    {
        private readonly ProductService<Bottle> _bottleService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateBottleController(ProductService<Bottle> bottleService, IWebHostEnvironment webHostEnvironment)
        {
            _bottleService = bottleService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet("Create")]
        public IActionResult CreateBottle()
        {
            return View();
        }


    }

   
    
}