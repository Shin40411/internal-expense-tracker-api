using Expense_tracker_api.Application.Interfaces.Repositories;
using Expense_tracker_api.Domain.Entities;

namespace Expense_tracker_api.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Wallet> Wallets { get; }
        IGenericRepository<Transaction> Transactions { get; }

        Task<int> SaveChangesAsync();
    }
}
