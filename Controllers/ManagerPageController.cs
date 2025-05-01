using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class ManagerPageController : Controller
    {
        public ManagerPageController()
        {
            ViewData["Layout"] = "~/Views/Shared/ManagerLayout";
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
