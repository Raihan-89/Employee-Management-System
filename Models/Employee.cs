using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee : UserActivity
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Position { get; set; }

        public string Department { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
