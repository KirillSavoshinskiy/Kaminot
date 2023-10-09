using WebApplication1.Data.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PaymentProcessService : IPaymentProcessService
{
    private readonly IPaymentSuffRepository _paymentSystemRepository;

    public PaymentProcessService(IPaymentSuffRepository paymentSystemRepository) => _paymentSystemRepository = paymentSystemRepository;
     
    public async Task<string> ProcessPaymentAsync(Payment payment, CancellationToken cancellationToken)
    { 
        var num = new Random().Next(1, 5);

        //random payment processing
        if (num == 1)
        {
            throw new Exception("Something went wrong while handling the payment! Please, try again.");
        }
        else
        {
            await _paymentSystemRepository.SetFinishedPaymentStatusAsync(payment, cancellationToken);
            return $"The {payment.Name} is successfully handled";
        }
    }
}