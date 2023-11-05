using Microsoft.AspNetCore.Mvc;

namespace DiabeticsSystem.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
