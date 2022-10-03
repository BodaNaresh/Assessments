using System.ComponentModel.DataAnnotations;

namespace CabManagementSysytem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Display(Name = "Official Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
         ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string Role { get; set; }
        public string ProfilePicture { get; set; }

    }
}
