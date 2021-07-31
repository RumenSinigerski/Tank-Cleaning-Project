using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static TankCleaningProject.Data.DataConsts.Company;

namespace TankCleaningProject.Data.Models
{
    public class Company
    {       
        public int Id { get; init; }
        [Required]
        [MaxLength(CompanyNameMaxLenght)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(EmailValidator)]
        public string Email { get; set; }
        [Required]
        [MaxLength(CompanyPhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }       
        public int Rating { get; set; } = 100;
        public IEnumerable<Wash> Washes { get; set; } = new List<Wash>();

    }
}
