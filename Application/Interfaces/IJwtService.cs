using Expense_tracker_api.Domain.Entities;

namespace Expense_tracker_api.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
