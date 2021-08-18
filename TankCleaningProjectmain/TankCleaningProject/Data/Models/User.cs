using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static TankCleaningProject.Data.DataConsts.User;

namespace TankCleaningProject.Data.Models
{
    public class User : IdentityUser
    {       

        [MaxLength(FullNameMaxLength)]
        public string Name { get; set; }
    }
}
