using OrderManagement.Entity;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DTO.Request
{
    public class OrderRequest
    {
        public int Id { get; set; }

  
        public int CustomerId { get; set; }


        public int ProductId { get; set; }


        public int Quantity { get; set; }


        public decimal TotalPrice { get; set; }


        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public Status Status { get; set; }
    }
}
