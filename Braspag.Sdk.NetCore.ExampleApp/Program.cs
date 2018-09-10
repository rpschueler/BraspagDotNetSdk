using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Braspag.Sdk.Contracts.Pagador;
using Braspag.Sdk.Pagador;
using Environment = Braspag.Sdk.Common.Environment;

namespace Braspag.Sdk.NetCore.ExampleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Braspag SDK Example App - C# / .NET Core");

            CreateCreditCardSaleAsync().Wait();
        }

        /// <summary>
        /// Cria um pagamento com cartão de crédito via Pagador
        /// </summary>
        private static async Task CreateCreditCardSaleAsync()
        {
            var pagadorClient = new PagadorClient(new PagadorClientOptions
            {
                Environment = Environment.Sandbox,
                Credentials = new MerchantCredentials
                {
                    MerchantId = "94E5EA52-79B0-7DBA-1867-BE7B081EDD97",
                    MerchantKey = "0123456789012345678901234567890123456789"
                }
            });

            var request = new SaleRequest
            {
                MerchantOrderId = DateTime.Now.Ticks.ToString(),
                Customer = new CustomerData
                {
                    Name = "Bjorn Ironside",
                    Birthdate = "1990-12-25",
                    IdentityType = "CPF",
                    Identity = "762.502.520-96",
                    Email = "bjorn.ironside@vikings.com.br",
                    Mobile = "11 99999-9999",
                    Phone = "11 8888-8888",
                    Address = new AddressData
                    {
                        Street = "Alameda Xingu",
                        Number = "512",
                        Complement = "27o andar",
                        District = "Alphaville",
                        City = "Barueri",
                        State = "SP",
                        Country = "Brasil",
                        ZipCode = "06455-030"
                    },
                    DeliveryAddress = new AddressData
                    {
                        Street = "Av. Marechal Camara",
                        Number = "160",
                        Complement = "934",
                        District = "Centro",
                        City = "Rio de Janeiro",
                        State = "RJ",
                        Country = "Brasil",
                        ZipCode = "20020-080"
                    }
                },
                Payment = new PaymentDataRequest
                {
                    Provider = "Simulado",
                    Type = "CreditCard",
                    Amount = 150000,
                    ServiceTaxAmount = 0,
                    Currency = "BRL",
                    Country = "BRA",
                    Installments = 1,
                    SoftDescriptor = "Braspag SDK",
                    CreditCard = new CreditCardData
                    {
                        CardNumber = "4485623136297301",
                        Holder = "BJORN IRONSIDE",
                        ExpirationDate = "12/2025",
                        SecurityCode = "123",
                        Brand = "visa",
                        SaveCard = true
                    },
                    ExtraDataCollection = new List<ExtraData>
                    {
                        new ExtraData
                        {
                            Name = "OrderNumber",
                            Value = "100000000"
                        }
                    }
                }
            };

            var response = await pagadorClient.CreateSaleAsync(request);

            Console.WriteLine($"Order ID: {response.MerchantOrderId}");
            Console.WriteLine($"Payment ID: {response.Payment.PaymentId}");
            Console.WriteLine($"Payment Status: {response.Payment.Status} [{response.Payment.GetStatusDescription()}]");
            Console.WriteLine("Press any key to close the app...");
            Console.ReadKey();
        }
    }
}
