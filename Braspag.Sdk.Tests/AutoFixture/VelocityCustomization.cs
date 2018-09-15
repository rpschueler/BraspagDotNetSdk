using AutoFixture;
using Braspag.Sdk.Velocity;
using Environment = Braspag.Sdk.Common.Environment;

namespace Braspag.Sdk.Tests.AutoFixture
{
    public class VelocityCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<VelocityClientOptions>(
                c => c
                    .With(x => x.Environment, Environment.Sandbox));
        }
    }
}