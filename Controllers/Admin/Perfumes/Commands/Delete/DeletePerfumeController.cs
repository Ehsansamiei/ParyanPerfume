using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Perfumes")]
    public class DeletePerfumeController : Controller
    {

        private readonly ProductService<Perfume> _perfumeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeletePerfumeController(ProductService<Perfume> perfumeService, IWebHostEnvironment webHostEnvironment)
        {
            _perfumeService = perfumeService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var product = _perfumeService.GetProductById(id);

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
            _perfumeService.DeleteProduct(product.Id);
            await _perfumeService.SaveAsync();

            return RedirectToAction("GetAllPerfumes", "GetPerfume");
        }
    }
}