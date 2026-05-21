using System.ComponentModel.DataAnnotations;

namespace CompanySystem.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        // Importance level: Low, Medium, High
        public string Importance { get; set; }

        // Foreign key to Employee
        public string EmployeeId { get; set; }    // string because IdentityUser Id is a string
        public Employee Employee { get; set; }
    }
}