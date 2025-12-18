using Expense_tracker_api.Application.DTOs.Transaction;
using Expense_tracker_api.Domain.Entities;

namespace Expense_tracker_api.Application.Interfaces
{
    public interface ITransactionService
    {
        Task CreateAsync(CreateTransactionDto dto, Guid userId);
        Task<IEnumerable<Transaction>> GetByMonthAsync(Guid userId, int year, int month);
    }
}
