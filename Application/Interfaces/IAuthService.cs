using Expense_tracker_api.Application.DTOs.Auth;

namespace Expense_tracker_api.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterDto dto);
        Task<AuthResponse> LoginAsync(LoginDto dto);
    }
}
