using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Fixators")]
    public class DeleteFixatorContorller : Controller
    {
        private readonly ProductService<Fixator> _fixatorService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteFixatorContorller(ProductService<Fixator> fixatorService, IWebHostEnvironment webHostEnvironment)
        {
            _fixatorService = fixatorService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteFixator(int id)
        {
            var fixator = _fixatorService.GetProductById(id);

            if (fixator == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(fixator.ImageName))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "FIxatorImages", fixator.ImageName);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _fixatorService.DeleteProduct(fixator.Id);
            await _fixatorService.SaveAsync();

            return RedirectToAction("GetAllFixators", "GetFIxator");
        }
    }
}