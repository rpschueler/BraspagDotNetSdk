using Braspag.Sdk.Contracts.BraspagAuth;
using System.Threading.Tasks;

namespace Braspag.Sdk.BraspagAuth
{
    public interface IBraspagAuthClient
    {
        Task<AccessTokenResponse> CreateAccessTokenAsync(AccessTokenRequest request);
    }
}