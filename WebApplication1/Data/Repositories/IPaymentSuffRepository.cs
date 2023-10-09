using WebApplication1.Models;

namespace WebApplication1.Data.Repositories
{
    public interface IPaymentSuffRepository
    {
        Task<IList<PaymentSystem>> GetAllPaymentSystemsAsync(CancellationToken token);
        Task<Payment> CreatePaymentAsync(Payment payment, int paymentSystemId, CancellationToken token);
        Task SetFinishedPaymentStatusAsync(Payment payment, CancellationToken token);
    }
}
