using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TankCleaningProject.Infrastructure;
using TankCleaningProject.Models.Wash;
using TankCleaningProject.Services;

namespace TankCleaningProject.Controllers
{
    public class WashController : Controller
    {
        private readonly WashService wash;
        private readonly UserService user;

        public WashController(WashService wash, UserService user)
        {
            this.wash = wash;
            this.user = user;
        }

        [Authorize]
        public IActionResult Index()
        {
            var products = this.wash.AllProductTypes();
            return View(new WashFormModel
            {
                ProductTypes = products
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(WashFormModel wash)
        {
            var companyId = this.user.IdByUser(this.User.Id());

            wash.ProductTypes = this.wash.AllProductTypes();

            if (!ModelState.IsValid || companyId == 0)
            {

                return View("Index",wash);
            }

            this.wash.Add(wash.RegistrationPlate,wash.DriverPhoneNumber,wash.DateAndTime,wash.DriverName,wash.ProductTypeId,companyId);

            return RedirectToAction("Index","Home");            
        }
    }
}
