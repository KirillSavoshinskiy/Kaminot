using MediatR;
using WebApplication1.Data.Repositories;
using WebApplication1.Mediator.Commands;
using WebApplication1.Models;

namespace WebApplication1.Mediator.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Payment>
    {
        private readonly IPaymentSuffRepository _paymentSystemRepository;

        public CreatePaymentCommandHandler(IPaymentSuffRepository paymentSystemRepository) => _paymentSystemRepository = paymentSystemRepository;

        public async Task<Payment> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                Name = request.Name,
                Amount = request.Amount,
                Description = request.Description,
                Status = "Active",
                Currency = request.Currency,
            };

            return await _paymentSystemRepository.CreatePaymentAsync(payment, request.PaymentSystemId, cancellationToken);
        }
    }
}
