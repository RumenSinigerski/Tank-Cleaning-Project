using TankCleaningProject.Data;
using TankCleaningProject.Data.Models;

namespace TankCleaningProject.Services
{
    public class CompanyService
    {
        private readonly ApplicationDbContext data;

        public CompanyService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(string name, string email, string phoneNumber, string userId)
        {
            var company = new Company
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                UserId = userId
            };

            this.data.Companies.Add(company);
            this.data.SaveChanges();
           
        }
    }
}
