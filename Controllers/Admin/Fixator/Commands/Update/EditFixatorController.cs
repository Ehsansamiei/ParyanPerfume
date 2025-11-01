using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.SignalR.Protocol;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Fixators")]
    public class EditFixatorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ProductService<Fixator> _fixatorService;

        public EditFixatorController(IWebHostEnvironment webHostEnvironment, ProductService<Fixator> fixatorService)
        {
            _webHostEnvironment = webHostEnvironment;
            _fixatorService = fixatorService;
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditFixator(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixator = _fixatorService.GetProductById(id.Value);

            if (fixator == null)
            {
                return NotFound();
            }

            var dto = new Fixator
            {
                Id = fixator.Id,
                Name = fixator.Name,
                Price = fixator.Price,
                PricePer20Liters = fixator.PricePer20Liters,
                ImageName = fixator.ImageName,
                Brand = fixator.Brand,
                Description = fixator.Description,
                IsAlcoholFree = fixator.IsAlcoholFree,
                ShowInSlider = fixator.ShowInSlider
            };

            return View(dto);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> EditFixator(FixatorsDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine("ModelState Errors: " + string.Join(" | ", errors));
                return View(dto);
            }

            var fixator = _fixatorService.GetProductById(dto.Id);
            if (fixator == null)
            {
                return NotFound();
            }
            fixator.Id = dto.Id;
            fixator.Name = dto.Name;
            fixator.Price = dto.Price;
            fixator.PricePer20Liters = dto.PricePer20Liters;
            fixator.Brand = dto.Brand;
            fixator.Description = dto.Description;
            fixator.IsAlcoholFree = dto.IsAlcoholFree;
            fixator.ShowInSlider = dto.ShowInSlider;

            if (dto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(fixator.ImageName))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "FixatorImages", fixator.ImageName);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(dto.ImageFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "FixatorImages");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var newPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                fixator.ImageName = fileName;
            }
            else if (!string.IsNullOrEmpty(dto.ImageName))
            {
                fixator.ImageName = dto.ImageName;
            }



            await _fixatorService.SaveAsync();
            return RedirectToAction("GetAllFixators", "GetFixator");
        }
    }
}