using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPaymentService
    {
        Task<IList<PaymentSystem>> GetPaymentSystemsAsync();
        Task<Payment> CreatePayment(PaymentDto payment);
        Task<string> ProcessPayment(Payment payment);
    }
}
