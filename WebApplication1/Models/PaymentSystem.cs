namespace WebApplication1.Models
{
    public class PaymentSystem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Currency> Currencies { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
