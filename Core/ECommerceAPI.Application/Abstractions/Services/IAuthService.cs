using ECommerceAPI.Application.Abstractions.Services.Authentications;
using System.Security;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {
        Task PasswordResetAsync(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}
