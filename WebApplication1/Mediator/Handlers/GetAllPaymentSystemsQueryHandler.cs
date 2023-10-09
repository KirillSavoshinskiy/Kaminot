using MediatR;
using WebApplication1.Data.Repositories;
using WebApplication1.Mediator.Queries;
using WebApplication1.Models;

namespace WebApplication1.Mediator.Handlers
{
    public class GetAllPaymentSystemsQueryHandler : IRequestHandler<GetAllPaymentSystemsQuery, IList<PaymentSystem>>
    {
        private readonly IPaymentSuffRepository _paymentSystemRepository;
     
        public GetAllPaymentSystemsQueryHandler(IPaymentSuffRepository paymentSystemRepository) => _paymentSystemRepository = paymentSystemRepository;

        public async Task<IList<PaymentSystem>> Handle(GetAllPaymentSystemsQuery request, CancellationToken cancellationToken)
            => await _paymentSystemRepository.GetAllPaymentSystemsAsync(cancellationToken);
    }
}
