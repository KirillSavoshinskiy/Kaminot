using MediatR;
using WebApplication1.DTOs;
using WebApplication1.Mediator.Commands;
using WebApplication1.Mediator.Queries;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMediator _mediator;

        public PaymentService(IMediator mediator) => _mediator = mediator;

        public async Task<IList<PaymentSystem>> GetPaymentSystemsAsync()
        {
            var command = new GetAllPaymentSystemsQuery(); 
            return await _mediator.Send(command);
        }

        public async Task<Payment> CreatePayment(PaymentDto payment)
        {
            var command = new CreatePaymentCommand()
            {
                PaymentSystemId = payment.PaymentSystemId,
                Name = payment.Name,
                Amount = payment.Amount,
                Description = payment.Description, 
                Currency = payment.Currency
            };
             
            return await _mediator.Send(command);
        }
    }
}
