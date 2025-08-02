using System.Runtime.CompilerServices;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Fixators")]
    public class CreateFixatorController : Controller
    {
        private readonly ProductService<Fixator> _fixatorService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateFixatorController(ProductService<Fixator> fixatorService, IWebHostEnvironment webHostEnvironment)
        {
            _fixatorService = fixatorService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Create")]
        public IActionResult CreateFixator()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateFixator(FixatorsDto fixatorsDto)
        {
            if (ModelState.IsValid)
            {
                var fixator = new Fixator
                {
                    Name = fixatorsDto.Name,
                    Description = fixatorsDto.Description,
                    Brand = fixatorsDto.Description,
                    Price = fixatorsDto.Price,
                    PricePer20Liters = fixatorsDto.PricePer20Liters,
                    CreatedAt = fixatorsDto.CreatedAt,
                    IsAlcoholFree = fixatorsDto.IsAlcoholFree,
                    ShowInSlider = fixatorsDto.ShowInSlider
                };

                if (fixatorsDto.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(fixatorsDto.ImageFile.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "FixatorImages");

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    string filePath2 = Path.Combine(filePath, fileName);

                    using (var filestream = new FileStream(filePath2, FileMode.Create))
                    {
                        await fixatorsDto.ImageFile.CopyToAsync(filestream);
                    }
                    fixator.ImageName = fileName;
                }
                _fixatorService.AddProduct(fixator);
                var result = await _fixatorService.SaveAsync();

                Console.WriteLine($"saved : {result}");
            }
            else
            {
                Console.WriteLine("ModelState is invalid");
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Error in {modelState.Key}: {error.ErrorMessage}");
                    }
                }
            }
            return RedirectToAction("GetAllFixators", "GetFixator");
        }
    }
}