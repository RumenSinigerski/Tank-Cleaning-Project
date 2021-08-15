using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TankCleaningProject.Data.Models;
using TankCleaningProject.Services.Models;
using static TankCleaningProject.Data.DataConsts.Wash;

namespace TankCleaningProject.Models.Wash
{
    public class WashFormModel
    {
        [MaxLength(RegistrationPlateMaxLenght)]
        public string RegistrationPlate { get; set; }

        [MaxLength(DriverPhoneNumberMaxLenght)]
        public string DriverPhoneNumber { get; set; }

        [Required]
        public string DateAndTime { get; set; }

        [MaxLength(DriverNameMaxLenght)]
        public string DriverName { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public IEnumerable<WashServiceModel> ProductTypes { get; set; }
        public int CompanyId { get; set; }
    }
}
