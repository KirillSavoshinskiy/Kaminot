using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Seed
    {
        public static async Task SeedInitialDataAsync(DataContext context)
        {
            if (await context.PaymentSystems.AnyAsync()) { return; }

            var pSystems = new List<PaymentSystem>
            {
                new PaymentSystem { Name = "PayPal", Description = "Description", Payments = new List<Payment>() },
                new PaymentSystem { Name = "Binance", Description = "Description", Payments = new List<Payment>() },
                new PaymentSystem { Name = "WebMoney", Description = "Description", Payments = new List<Payment>() }
            };

            await context.AddRangeAsync(pSystems);

            var currencies = new List<Currency> {
                new Currency { Name = "USD", IsCrypto = false },
                new Currency { Name = "EUR", IsCrypto = false },
                new Currency { Name = "BYN", IsCrypto = false },
                new Currency { Name = "BIT", IsCrypto = true },
                new Currency { Name = "USDT", IsCrypto = true }
            };

            await context.AddRangeAsync(currencies);

            var payments = new List<Payment>
            {
                new Payment { Name = "Payment1", Amount = 120, Status = "Active", Description = "Description", Currency = currencies[0]},
                new Payment { Name = "Payment2", Amount = 20, Status = "In progress", Description = "Description" , Currency = currencies[1]},
                new Payment { Name = "Payment3", Amount = 320, Status = "Active", Description = "Description" , Currency = currencies[2]},
                new Payment { Name = "Payment4", Amount = 550, Status = "Finished", Description = "Description" , Currency = currencies[0]}
            }; 

            pSystems[0].Currencies = new List<Currency> { currencies[0], currencies[1], currencies[2] };
            pSystems[0].Payments = payments;
            pSystems[1].Currencies = new List<Currency> { currencies[3], currencies[4] };
            pSystems[2].Currencies = new List<Currency> { currencies[0], currencies[1], currencies[4], currencies[3] };

            await context.SaveChangesAsync();
        }
    }
}
