using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Bottles")]
    public class DeleteBottleController : Controller
    {
        private readonly ProductService<Bottle> _bottleService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteBottleController(ProductService<Bottle> bottleService, IWebHostEnvironment webHostEnvironment)
        {
            _bottleService = bottleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteBottle(int id)
        {
            var bottle = _bottleService.GetProductById(id);
            if (bottle == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(bottle.ImageName))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "BottleImages", bottle.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _bottleService.DeleteProduct(bottle.Id);
            await _bottleService.SaveAsync();

            return RedirectToAction("GetAllBottles", "GetBottles");
        }
    }
}