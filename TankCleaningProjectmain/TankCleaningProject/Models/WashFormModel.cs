using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TankCleaningProject.Data.Models;
using static TankCleaningProject.Data.DataConsts.Wash;

namespace TankCleaningProject.Models.Wash
{
    public class WashFormModel
    {
        public int Id { get; set; }
        [MaxLength(RegistrationPlateMaxLenght)]
        public string RegistrationPlate { get; set; }

        [MaxLength(DriverPhoneNumberMaxLenght)]
        public string DriversPhoneNumber { get; set; }

        [Required]
        public string DateAndTime { get; set; }

        [MaxLength(DriverNameMaxLenght)]
        public string DriverName { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public List<ProductType> ProductTypes { get; set; }
        public int CompanyId { get; set; }
    }
}