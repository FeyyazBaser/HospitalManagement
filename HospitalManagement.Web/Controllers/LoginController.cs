using HospitalManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HospitalManagement.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserInfo user)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7053/api/Login", stringContent))
                {

                    string token = await response.Content.ReadAsStringAsync();
                    

                    if (token.Contains("error"))
                        
                        return View("Index");
                    HttpContext.Session.SetString("JwtToken", token);
                }

                return Redirect("~/Home");
            }

        }
    }
}
