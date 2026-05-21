using System.ComponentModel.DataAnnotations;

namespace CompanySystem.ViewModels
{
    public class RegisterEmployeeViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string NationalId { get; set; }

        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime EntryDate { get; set; }
        public int DepartmentId { get; set; }

        // For uploading photo
        public IFormFile? Photo { get; set; }
    }
}