

using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin/Perfumes")]
    public class GetPerfumeController : Controller
    {
        private readonly IPerfumeRepository _perfumeRepository;

        public GetPerfumeController(IPerfumeRepository perfumeRepository)
        {
            _perfumeRepository = perfumeRepository;
        }

        [HttpGet]
        public IActionResult GetAllPerfumes()
        {
            var perfumes = _perfumeRepository.GetAllPerfumes();
            return View(perfumes);
        }
    }
}