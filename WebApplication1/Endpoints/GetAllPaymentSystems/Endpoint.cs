using WebApplication1.Services;

namespace WebApplication1.Endpoints.GetAllPaymentSystems
{
    public static class Endpoint
    {
        public static WebApplication MapGetAllStudents(this WebApplication app)
        {
            app.MapGet("payment-system/get-all", async (IPaymentService paymentService) =>
            {
                try
                {
                    var paymentSystems = await paymentService.GetPaymentSystemsAsync();
                    return paymentSystems != null ? Results.Ok(paymentSystems) : Results.NotFound();
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
