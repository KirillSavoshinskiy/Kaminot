using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Mediator.Queries
{
    public class GetAllPaymentSystemsQuery : IRequest<IList<PaymentSystem>>
    {
    }
}
