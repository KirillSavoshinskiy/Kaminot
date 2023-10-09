using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Mediator.Commands
{
    public class CreatePaymentCommand : IRequest<Payment>
    {
        public int PaymentSystemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
