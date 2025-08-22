using System.Security.AccessControl;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Accesories")]
    public class CreateAccesoryController : Controller
    {
        private readonly ProductService<Pocket> _accesoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateAccesoryController(ProductService<Pocket> accesoryService, IWebHostEnvironment webHostEnvironment)
        {
            _accesoryService = accesoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Create")]
        public IActionResult CreateAccesory()
        {
            return View();
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccesory(AccesoriesDto accesoriesDto)
        {
            if (ModelState.IsValid)
            {
                var accesory = new Pocket
                {
                    Name = accesoriesDto.Name,
                    Description = accesoriesDto.Description,
                    Brand = accesoriesDto.Brand,
                    Price = accesoriesDto.Price,
                    CreatedAt = DateTime.Now,
                    QuantityInCarton = accesoriesDto.QuantityInCarton,
                    QuantityInPackaging = accesoriesDto.QuantityInPackaging,
                    ShowInSlider = accesoriesDto.ShowInSlider
                };

                if (accesoriesDto.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(accesoriesDto.ImageFile.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "BottleImages");

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    string filePath2 = Path.Combine(filePath, fileName);

                    using (var filestream = new FileStream(filePath2, FileMode.Create))
                    {
                        await accesoriesDto.ImageFile.CopyToAsync(filestream);
                    }
                    accesory.ImageName = fileName;
                }
                _accesoryService.AddProduct(accesory);
                var result = await _accesoryService.SaveAsync();
                Console.WriteLine($"saved :  {result}");
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
            return RedirectToAction("GetAllAccesories", "GetAccesory");
        }
    }
}