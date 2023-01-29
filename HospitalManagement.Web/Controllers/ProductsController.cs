using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace HospitalManagement.Web.Controllers
{
    public class ProductsController : Controller
    {

        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
