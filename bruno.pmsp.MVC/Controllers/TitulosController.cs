using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace bruno.pmsp.MVC.Controllers
{
    public class TitulosController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult teste()
        {
            var obj = new {
                nome = "Bruno Afonso",
                cargo = "ATE"
            };

            return Json(JsonConvert.SerializeObject(obj));
        }
    }
}