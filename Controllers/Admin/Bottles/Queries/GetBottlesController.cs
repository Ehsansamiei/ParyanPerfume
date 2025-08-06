using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Bottles")]
    public class GetBottlesController : Controller
    {
        private readonly ProductService<Bottle> _bottleService;

        public GetBottlesController(ProductService<Bottle> bottleService)
        {
            _bottleService = bottleService;
        }


        [HttpGet]
        public IActionResult GetAllBottles()
        {
            var bottles = _bottleService.GetAllProducts();
            return View(bottles);
        }
    }
}