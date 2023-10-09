using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPaymentService
    {
        Task<IList<PaymentSystem>> GetPaymentSystemsAsync();
    }
}
