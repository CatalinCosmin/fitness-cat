using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.EntityControllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
