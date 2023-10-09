using MediatR;
using WebApplication1.Models;

namespace WebApplication1.Mediator.Commands
{
    public class PayCommand : IRequest<string>
    {
        public Payment Payment { get; set; }
    }
}
