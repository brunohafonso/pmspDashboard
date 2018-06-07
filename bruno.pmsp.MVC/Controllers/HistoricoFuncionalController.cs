using Microsoft.AspNetCore.Mvc;

namespace bruno.pmsp.MVC.Controllers
{
    public class HistoricoFuncionalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}