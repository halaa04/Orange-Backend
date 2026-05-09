using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}