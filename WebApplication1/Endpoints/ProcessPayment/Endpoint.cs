using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Endpoints.ProcessPayment
{
    public static class Endpoint
    {
        public static WebApplication MapProcessPayment(this WebApplication app)
        {
            app.MapPost("payment-system/process-payment", async (Payment payment, IPaymentService paymentService) =>
            {
                try
                { 
                    var message = await paymentService.ProcessPayment(payment);
                    return Results.Ok(message);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });


            return app;
        }
    }
}
