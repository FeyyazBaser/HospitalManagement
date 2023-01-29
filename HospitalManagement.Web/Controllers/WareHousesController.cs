using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Controllers
{
    public class WareHousesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
