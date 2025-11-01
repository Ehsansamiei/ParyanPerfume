using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;

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

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBottle(BottlesDto bottlesDto)
        {
            if (ModelState.IsValid)
            {
                var bottle = new Bottle
                {
                    Name = bottlesDto.Name,
                    Description = bottlesDto.Description,
                    Brand = bottlesDto.Brand,
                    CreatedAt = DateTime.Now,
                    Price = bottlesDto.Price,
                    Material = bottlesDto.Material,
                    QuantityInCarton = bottlesDto.QuantityInCarton,
                    QuantityInPackaging = bottlesDto.QuantityInPackaging,
                    Volume = bottlesDto.Volume
                };

                if (bottlesDto.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(bottlesDto.ImageFile.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "BottleImages");

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string filePath2 = Path.Combine(filePath, fileName);

                    using (var filestream = new FileStream(filePath2, FileMode.Create))
                    {
                        await bottlesDto.ImageFile.CopyToAsync(filestream);
                    }
                    bottle.ImageName = fileName;
                }

                _bottleService.AddProduct(bottle);
                var result = await _bottleService.SaveAsync();
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
            return RedirectToAction("GetAllBottles", "GetBottles");
        }
    }
}