using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPaymentProcessService
    {
        Task<string> ProcessPaymentAsync(Payment payment, CancellationToken cancellationToken);
    }
}
