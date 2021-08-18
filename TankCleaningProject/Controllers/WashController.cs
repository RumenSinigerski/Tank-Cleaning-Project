using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using TankCleaningProject.Infrastructure;
using TankCleaningProject.Models.Appointment;
using TankCleaningProject.Models.Wash;
using TankCleaningProject.Services;

namespace TankCleaningProject.Controllers
{
    public class WashController : Controller
    {
        private readonly WashService washData;
        private readonly UserService user;

        public WashController(WashService wash, UserService user)
        {
            this.washData = wash;
            this.user = user;
        }

        [Authorize]
        public IActionResult Index()
        {
            var products = this.washData.AllProductTypes();
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

            wash.ProductTypes = this.washData.AllProductTypes();

            if (!ModelState.IsValid || companyId == 0)
            {

                return View("Index",wash);
            }

            this.washData.Add(wash.RegistrationPlate,wash.DriversPhoneNumber,wash.DateAndTime,wash.DriverName,wash.ProductTypeId,companyId);

            return RedirectToAction("Index","Home");            
        }

        
        [Authorize]
        public IActionResult ByDay()
        {          
            if (this.user.IdByUser(this.User.Id()) == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult ByDay(AllAppointmentsQueryModel model)
        {
            //if (DateTime.Parse(model.Date.ToString()) > DateTime.Parse(DateTime.Now.ToString("dd.MM.yyyy")))
            //{
            //    return View(model);
            //}

            return RedirectToAction("All", model);
        }

        [Authorize]
        public IActionResult All([FromQuery]AllAppointmentsQueryModel model)
        {
            model.CompanyId = this.user.IdByUser(this.User.Id());

            if (model.CompanyId == 0)
            {
                return RedirectToAction("Index","Home");
            }

            var result = washData.All(model);

            return View(result);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var model = this.washData.FindById(id);
            model.ProductTypes = this.washData.AllProductTypes();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(WashFormModel wash)
        {
            wash.ProductTypes = this.washData.AllProductTypes();
            this.washData.Edit(wash);



            return RedirectToAction("ByDay");
        }
    }
}
