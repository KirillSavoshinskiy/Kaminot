using MediatR;
using WebApplication1.Mediator.Commands;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Mediator.Handlers
{
    public class PayCommandHandler : IRequestHandler<PayCommand, string>
    {
        private readonly IPaymentProcessService _paymentProcessService;

        public PayCommandHandler(IPaymentProcessService paymentProcessService) => _paymentProcessService = paymentProcessService;

        public async Task<string> Handle(PayCommand request, CancellationToken cancellationToken)
            => await _paymentProcessService.ProcessPaymentAsync(request.Payment, cancellationToken);
    }
}
