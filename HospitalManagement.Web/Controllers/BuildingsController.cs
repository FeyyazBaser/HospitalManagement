using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class BuildingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
