using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace OrderManagement.Entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
