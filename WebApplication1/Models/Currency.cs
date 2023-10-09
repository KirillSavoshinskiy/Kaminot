using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCrypto { get; set; }

        [JsonIgnore]
        public ICollection<Payment> Payments { get; set; }

        [JsonIgnore]
        public ICollection<PaymentSystem> PaymentSystems { get; set; }
    }
}
