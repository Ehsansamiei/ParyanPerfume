using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Perfumes")]
    public class DeletePerfumeController : Controller
    {
        private readonly IPerfumeRepository _perfumeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeletePerfumeController(IPerfumeRepository perfumeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _perfumeRepository = perfumeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var product = _perfumeRepository.GetPerfumeById(id);
            if (product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(product.ImageName))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages", product.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

            }
            _perfumeRepository.DeletePerfume(product);
            await _perfumeRepository.SaveAsync();

            return RedirectToAction("GetAllPerfumes", "GetPerfume");
        }
    }
}