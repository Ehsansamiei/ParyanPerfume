using DataLayer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Perfumes")]
    public class EditPerfumeController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ParyanPerfumeDbContext _paryanPerfumeDbContext;
        private readonly ProductService<Perfume> _perfumeService;

        public EditPerfumeController(ParyanPerfumeDbContext paryanPerfumeDbContext, IWebHostEnvironment webHostEnvironment, ProductService<Perfume> perfumeService)
        {

            _webHostEnvironment = webHostEnvironment;
            _paryanPerfumeDbContext = paryanPerfumeDbContext;
            _perfumeService = perfumeService;
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditPerfume(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _perfumeService.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var dto = new Perfume
            {

                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                PricePer100gram = product.PricePer100gram,
                ImageName = product.ImageName,
                Brand = product.Brand,
                Description = product.Description,
                Gender = product.Gender,
                ShowInSlider = product.ShowInSlider
            };


            return View(dto);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> EditPerfume(PerfumesDto Dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine("ModelState Errors: " + string.Join(" | ", errors));
                return View(Dto);
            }

            var perfume = _perfumeService.GetProductById(Dto.Id);
            if (perfume == null)
            {
                return NotFound();
            }

          
            perfume.Name = Dto.Name;
            perfume.Price = Dto.Price;
            perfume.PricePer100gram = Dto.PricePer100gram;
            perfume.Brand = Dto.Brand;
            perfume.Description = Dto.Description;
            perfume.Gender = Dto.Gender;
            perfume.ShowInSlider = Dto.ShowInSlider;

            if (Dto.ImageFile != null)
            {
                
                if (!string.IsNullOrEmpty(perfume.ImageName))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "PerfumeImages", perfume.ImageName);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(Dto.ImageFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "PerfumeImages");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var newPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await Dto.ImageFile.CopyToAsync(stream);
                }

                perfume.ImageName = fileName;
            }
            else if (string.IsNullOrEmpty(perfume.ImageName) && !string.IsNullOrEmpty(Dto.ImageName))
            {
                perfume.ImageName = Dto.ImageName;
            }

            await _perfumeService.SaveAsync();
            return RedirectToAction("GetAllPerfumes", "GetPerfume");
        }
    }
}