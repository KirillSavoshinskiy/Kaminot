using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class Payment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }

    [JsonIgnore]
    public PaymentSystem PaymentSystem { get; set; }
    public string Status { get; set; }
}