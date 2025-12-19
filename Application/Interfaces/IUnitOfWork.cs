using Expense_tracker_api.Application.Interfaces.Repositories;
using Expense_tracker_api.Domain.Entities;

namespace Expense_tracker_api.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Wallet> Wallets { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Transaction> Transactions { get; }

        Task<int> SaveChangesAsync();
    }
}
