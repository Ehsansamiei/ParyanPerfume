using System.Reflection.Metadata.Ecma335;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Accesories")]
    public class EditAccesoryController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ProductService<Pocket> _accesoryService;

        public EditAccesoryController(IWebHostEnvironment webHostEnvironment, ProductService<Pocket> accesoryService)
        {
            _accesoryService = accesoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Edit/{id}")]
        public IActionResult EditAccesory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var accesory = _accesoryService.GetProductById(id.Value);

            if (accesory == null)
            {
                return NotFound();
            }

            var dto = new Pocket
            {
                Id = accesory.Id,
                Name = accesory.Name,
                Price = accesory.Price,
                Brand = accesory.Brand,
                Description = accesory.Description,
                ImageName = accesory.ImageName,
                QuantityInCarton = accesory.QuantityInCarton,
                QuantityInPackaging = accesory.QuantityInPackaging
            };
            return View(dto);
        }
    }
}