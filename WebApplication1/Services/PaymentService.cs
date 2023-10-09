using MediatR;
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
            var pSystems = await _mediator.Send(command);
            return pSystems; 
        }
    }
}
