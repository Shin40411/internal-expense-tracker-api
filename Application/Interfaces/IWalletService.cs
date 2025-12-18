using Expense_tracker_api.Application.DTOs.Wallet;
using Expense_tracker_api.Domain.Entities;

namespace Expense_tracker_api.Application.Interfaces
{
    public interface IWalletService
    {
        Task<IEnumerable<Wallet>> GetAllAsync(Guid userId);
        Task<Wallet> CreateAsync(CreateWalletDto dto, Guid userId);
    }

}
