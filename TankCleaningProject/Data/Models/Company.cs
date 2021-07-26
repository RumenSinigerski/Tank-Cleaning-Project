using System;
using System.Collections.Generic;

namespace TankCleaningProject.Data.Models
{
    public class Company
    {
        public Guid Id { get; init; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; } = 100;

        public IEnumerable<Wash> Washes { get; set; }

    }
}
