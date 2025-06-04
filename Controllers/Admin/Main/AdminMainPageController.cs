using Microsoft.AspNetCore.Mvc;

namespace ParyanPerfume.Controllers.Admin
{
    [Route("Admin")]
    public class AdminMainPageController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}