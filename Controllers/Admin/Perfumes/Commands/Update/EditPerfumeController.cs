using DataLayer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;


namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Perfumes")]
    public class EditPerfumeController : Controller
    {
        private readonly IPerfumeRepository _perfumeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ParyanPerfumeDbContext _paryanPerfumeDbContext;

        public EditPerfumeController(IPerfumeRepository perfumeRepository,  ParyanPerfumeDbContext paryanPerfumeDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _perfumeRepository = perfumeRepository;
            _webHostEnvironment = webHostEnvironment;
            _paryanPerfumeDbContext = paryanPerfumeDbContext;
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _perfumeRepository.GetPerfumeById(id.Value);
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
        public async Task<IActionResult> EditProduct(PerfumesDto Dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine("ModelState Errors: " + string.Join(" | ", errors));
                return View(Dto);
            }

            var perfume = _perfumeRepository.GetPerfumeById(Dto.Id);
            if (perfume == null)
            {
                return NotFound();
            }
            
            perfume.Id = perfume.Id;
            perfume.Name = perfume.Name;
            perfume.Price = perfume.Price;
            perfume.PricePer100gram = perfume.PricePer100gram;
            perfume.ImageName = perfume.ImageName;
            perfume.Brand = perfume.Brand;
            perfume.Description = perfume.Description;
            perfume.Gender = perfume.Gender;
            perfume.ShowInSlider = perfume.ShowInSlider;

            if (Dto.ImageFile == null && !string.IsNullOrEmpty(Dto.ImageName)) {
                perfume.ImageName = Dto.ImageName;
            }

            if (Dto.ImageFile != null) {
                if (!string.IsNullOrEmpty(perfume.ImageName))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages", perfume.ImageName);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(Dto.ImageFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");

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

            await _perfumeRepository.SaveAsync();
            return RedirectToAction("GetAllProducts", "GetProdcut");
        }
    }
}