using Braspag.Sdk.Contracts.Velocity;
using System.Threading.Tasks;

namespace Braspag.Sdk.Velocity
{
    public interface IVelocityClient
    {
        Task<AnalysisResponse> PerformAnalysisAsync(AnalysisRequest request, MerchantCredentials credentials = null);
    }
}