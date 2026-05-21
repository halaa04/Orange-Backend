using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CompanySystem.Models
{
    public class Employee : IdentityUser
    {
        // IdentityUser already gives us: Id, Email, PasswordHash, UserName

        [Required]
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string NationalId { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string PhotoPath { get; set; }       // stores the file path of the photo
        public DateTime EntryDate { get; set; }

        // Foreign key to Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // One employee has many tasks
        public ICollection<EmployeeTask> Tasks { get; set; }
    }
}