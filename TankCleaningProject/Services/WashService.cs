using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TankCleaningProject.Data;
using TankCleaningProject.Data.Models;
using TankCleaningProject.Models.Appointment;
using TankCleaningProject.Models.Wash;

namespace TankCleaningProject.Services
{
    public class WashService
    {
        private readonly ApplicationDbContext data;

        public WashService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public List<ProductType> AllProductTypes()
        {
            var result = this.data
               .ProductTypes
               .Select(w => new ProductType
               {
                   Id = w.Id,
                   Price = w.Price,
                   Name = w.Name
               })
               .ToList();

            return result;
        }

        public int Add(string registrationPlate, string driverPhoneNumber, string dateAndTime, string driverName, int productTypeId, int companyId)
        {
            var washData = new Wash
            {
                RegistrationPlate = registrationPlate,
                DriverPhoneNumber = driverPhoneNumber,
                DriverName = driverName,
                DateAndTime = dateAndTime,
                ProductTypeId = productTypeId,
                CompanyId = companyId
            };

            this.data.Washes.Add(washData);
            this.data.SaveChanges();

            return washData.Id;
        }

        public IEnumerable<WashFormModel> All(AllAppointmentsQueryModel model)
        {

            var result = this.data.Washes
                .Where(w => w.CompanyId == model.CompanyId && w.DateAndTime.Contains(model.Date))
                .Select(w => new WashFormModel
                {
                    Id = w.Id,
                    CompanyId = w.CompanyId,
                    DateAndTime = w.DateAndTime,
                    DriverName = w.DriverName,
                    DriversPhoneNumber = w.DriverPhoneNumber,
                    ProductTypeId = w.ProductTypeId,
                    RegistrationPlate = w.RegistrationPlate,
                    ProductTypes = new List<ProductType>(){ w.ProductType }
                })
                .ToList();

            return result;
        }

        public WashFormModel FindById(int id)
        {
            var result = this.data.Washes
                .Where(w => w.Id == id)
                .Select(w => new WashFormModel
                {
                    Id = w.Id,
                    CompanyId = w.CompanyId,
                    DateAndTime = w.DateAndTime,
                    DriverName = w.DriverName,
                    DriversPhoneNumber = w.DriverPhoneNumber,
                    ProductTypeId = w.ProductTypeId,
                    RegistrationPlate = w.RegistrationPlate,
                    ProductTypes = new List<ProductType>() { w.ProductType }
                }).FirstOrDefault();

            return result;
        }

        public bool Edit(WashFormModel model)
        {
            var wash = this.data.Washes.FirstOrDefault(w => w.Id == model.Id);

            wash.DateAndTime = model.DateAndTime;
            wash.DriverName = model.DriverName;
            wash.DriverPhoneNumber = model.DriversPhoneNumber;
            wash.ProductTypeId = model.ProductTypeId;
            wash.RegistrationPlate = model.RegistrationPlate;
            wash.ProductType = (ProductType)model.ProductTypes.Find(p => p.Id == model.ProductTypeId);

            this.data.SaveChanges();

            return true;
        }
    }
}
