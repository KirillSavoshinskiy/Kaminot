using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class PaymentDto
    {
        public int PaymentSystemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
