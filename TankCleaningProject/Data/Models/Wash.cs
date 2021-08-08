using System.ComponentModel.DataAnnotations;
using static TankCleaningProject.Data.DataConsts.Wash;


namespace TankCleaningProject.Data.Models
{
    public class Wash
    {
        public int Id { get; init; }

        [MaxLength(RegistrationPlateMaxLenght)]
        public string RegistrationPlate { get; set; }

        [MaxLength(DriverPhoneNumberMaxLenght)]
        public string DriverPhoneNumber { get; set; }

        [Required]
        public string DateAndTime { get; set; }

        [MaxLength(DriverNameMaxLenght)]
        public string DriverName { get; set; }

        public int ProductTypeId { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        public bool IsWashed { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

    }
}
