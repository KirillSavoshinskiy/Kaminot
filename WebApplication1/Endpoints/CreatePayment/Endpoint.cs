using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Endpoints.CreatePayment
{
    public static class Endpoint
    {
        public static WebApplication MapPostCreatePayment(this WebApplication app)
        {
            app.MapPost("payment-system/create-payment", async (PaymentDto paymentDto, IPaymentService paymentService) =>
                {
                    try
                    {
                        var payment = await paymentService.CreatePayment(paymentDto);
                        return Results.Ok(payment);
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
