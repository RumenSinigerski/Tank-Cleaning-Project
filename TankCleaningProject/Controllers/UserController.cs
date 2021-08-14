using Microsoft.AspNetCore.Mvc;
using TankCleaningProject.Data;

namespace TankCleaningProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext data;

        public UserController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
