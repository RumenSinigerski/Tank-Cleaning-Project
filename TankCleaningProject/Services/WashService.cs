using System.Collections.Generic;
using System.Linq;
using TankCleaningProject.Data;
using TankCleaningProject.Data.Models;
using TankCleaningProject.Services.Models;


namespace TankCleaningProject.Services
{
    public class WashService
    {
        private readonly ApplicationDbContext data;

        public WashService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<WashServiceModel> AllProductTypes()
        {
            var result = this.data
               .ProductTypes
               .Select(w => new WashServiceModel
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
    }
}
