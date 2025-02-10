using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Entity
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int stock { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
