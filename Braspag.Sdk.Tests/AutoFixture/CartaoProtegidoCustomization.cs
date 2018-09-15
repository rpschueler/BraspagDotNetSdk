using AutoFixture;
using Braspag.Sdk.CartaoProtegido;
using Braspag.Sdk.Contracts.CartaoProtegido;
using Environment = Braspag.Sdk.Common.Environment;

namespace Braspag.Sdk.Tests.AutoFixture
{
    public class CartaoProtegidoCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<CartaoProtegidoClientOptions>(
                c => c
                    .With(x => x.Environment, Environment.Sandbox)
                    .With(x => x.Credentials, new MerchantCredentials
                    {
                        MerchantKey = "106c8a0c-89a4-4063-bf50-9e6c8530593b"
                    }));
        }
    }
}