using System.Linq;
using TankCleaningProject.Data;

namespace TankCleaningProject.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int IdByUser(string userId)
        {
            var companyId = this.data
                  .Companies
                  .Where(c => c.UserId == userId)
                  .Select(c => c.Id)
                  .FirstOrDefault();

            return companyId;
        }
    }
}
