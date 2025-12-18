using Expense_tracker_api.Application.Interfaces;
using Expense_tracker_api.Application.Interfaces.Repositories;
using Expense_tracker_api.Domain.Entities;
using Expense_tracker_api.Infrastructure.Data;
using Expense_tracker_api.Infrastructure.Repositories;

namespace Expense_tracker_api.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Wallet> Wallets { get; }
        public IGenericRepository<Transaction> Transactions { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Wallets = new GenericRepository<Wallet>(_context);
            Transactions = new GenericRepository<Transaction>(_context);
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
