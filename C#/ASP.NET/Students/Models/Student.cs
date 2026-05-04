using System.ComponentModel.DataAnnotations;

namespace StudentsCRUD.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(1, 150, ErrorMessage = "Age must be greater than 0")]
        public int Age { get; set; }
    }
}