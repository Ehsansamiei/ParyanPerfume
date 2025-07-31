

using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParyanPerfume.Dtos;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Perfumes")]

    public class CreatePerfumeController : Controller
    {
       
        private readonly ProductService<Perfume> _perfumeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreatePerfumeController(ProductService<Perfume> perfumeService, IWebHostEnvironment webHostEnvironment)
        {

            _webHostEnvironment = webHostEnvironment;
            _perfumeService = perfumeService;
        }


        [HttpGet("Create")]
        public IActionResult CreatePerfume()
        {
            
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePerfume(PerfumesDto perfumesDto)
        {
            if (ModelState.IsValid)
            {
                var perfume = new Perfume
                {
                  
                    Name = perfumesDto.Name,
                    Description = perfumesDto.Description,
                    Brand = perfumesDto.Brand,
                    Gender = perfumesDto.Gender,
                    Price = perfumesDto.Price,
                    PricePer100gram = perfumesDto.Price,
                    CreatedAt = DateTime.Now,
                };


                if (perfumesDto.ImageFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(perfumesDto.ImageFile.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "PerfumeImages");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string filePath2 = Path.Combine(filePath, fileName);
                    using (var filestream = new FileStream(filePath2, FileMode.Create))
                    {
                        await perfumesDto.ImageFile.CopyToAsync(filestream);
                    }
                    perfume.ImageName = fileName;
                }
                _perfumeService.AddProduct(perfume);
                var result = await _perfumeService.SaveAsync();

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
            return RedirectToAction("GetAllPerfumes", "GetPerfume");
        }
    }
}