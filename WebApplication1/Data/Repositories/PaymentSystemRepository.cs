using Microsoft.EntityFrameworkCore; 
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories
{
    public class PaymentSystemRepository : IPaymentSystemRepository
    {
        private readonly DataContext _dataContext;

        public PaymentSystemRepository(DataContext dataContext) => _dataContext = dataContext;
        
        public async Task<IList<PaymentSystem>> GetAllPaymentSystemsAsync(CancellationToken token) 
            => await _dataContext.PaymentSystems
            .Include(c => c.Currencies)
            .Include(p => p.Payments)
            .ThenInclude(c => c.Currency)
            .AsNoTracking()
            .ToListAsync(token);

        public async Task<Payment> CreatePaymentAsync(Payment payment, int paymentSystemId, CancellationToken token)
        {
            var pSystem = await _dataContext.PaymentSystems.Include(p => p.Payments).FirstOrDefaultAsync(s => s.Id == paymentSystemId); 
            pSystem?.Payments.Add(payment); 
            await _dataContext.SaveChangesAsync();
            return payment;
        }
    }
}
