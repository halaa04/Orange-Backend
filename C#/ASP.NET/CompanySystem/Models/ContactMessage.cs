using System.ComponentModel.DataAnnotations;

namespace CompanySystem.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        public string SenderName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}