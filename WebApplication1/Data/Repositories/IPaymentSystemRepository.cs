using WebApplication1.Models;

namespace WebApplication1.Data.Repositories
{
    public interface IPaymentSystemRepository
    {
        Task<IList<PaymentSystem>> GetAllPaymentSystemsAsync(CancellationToken token);
    }
}
