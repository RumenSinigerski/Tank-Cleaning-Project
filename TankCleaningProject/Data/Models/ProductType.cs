using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TankCleaningProject.Data.Models
{
    public class ProductType
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        public double Price { get; set; } = 0.00;

        public IEnumerable<Wash> Washes { get; set; } = new List<Wash>();
    }
}
