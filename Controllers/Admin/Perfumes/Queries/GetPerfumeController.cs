

using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Perfumes")]
    public class GetPerfumeController : Controller
    {
        
        private readonly ProductService<Perfume> _perfumeService;

        public GetPerfumeController(ProductService<Perfume> perfumeService)
        {
            _perfumeService = perfumeService;
        }

        [HttpGet]
        public IActionResult GetAllPerfumes()
        {
            var perfumes = _perfumeService.GetAllProducts();
            return View(perfumes);
        }
    }
}