

using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Bottles")]
    public class EditBottleController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ProductService<Bottle> _bottleService;

        public EditBottleController(IWebHostEnvironment webHostEnvironment, ProductService<Bottle> bottleService)
        {
            _bottleService = bottleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditBottle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bottle = _bottleService.GetProductById(id.Value);

            if (bottle == null)
            {
                return NotFound();
            }

            var dto = new Bottle
            {
                Id = bottle.Id,
                Name = bottle.Name,
                Price = bottle.Price,
                Brand = bottle.Brand,
                Description = bottle.Description,
                ImageName = bottle.ImageName,
                Material = bottle.Material,
                Volume = bottle.Volume,
                QuantityInCarton = bottle.QuantityInCarton,
                QuantityInPackaging = bottle.QuantityInPackaging
            };
            return View(dto);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> EditBottle(BottlesDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine("ModelState Errors: " + string.Join(" | ", errors));
                return View(dto);
            }

            var bottle = _bottleService.GetProductById(dto.Id);
            if (bottle == null)
            {
                return NotFound();
            }
            bottle.Id = bottle.Id;
            bottle.Name = bottle.Name;
            bottle.Price = bottle.Price;
            bottle.Brand = bottle.Brand;
            bottle.Description = bottle.Description;
            bottle.ImageName = bottle.ImageName;
            bottle.Material = bottle.Material;
            bottle.Volume = bottle.Volume;
            bottle.QuantityInCarton = bottle.QuantityInCarton;
            bottle.QuantityInPackaging = bottle.QuantityInPackaging;

            if (dto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(bottle.ImageName))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "BottleImages", bottle.ImageName);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(dto.ImageFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "BottleImages");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var newPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                bottle.ImageName = fileName;
            }
            else if (!string.IsNullOrEmpty(dto.ImageName))
            {
                bottle.ImageName = dto.ImageName;
            }


            await _bottleService.SaveAsync();
            return RedirectToAction("GetAllBottles", "GetBottles");
        }
    }
}