using Microsoft.AspNetCore.Mvc;

namespace MyNote.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
