using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
