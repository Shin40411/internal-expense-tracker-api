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

        public IGenericRepository<User> Users {  get; }
        public IGenericRepository<Wallet> Wallets { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Transaction> Transactions { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new GenericRepository<User>(_context);
            Wallets = new GenericRepository<Wallet>(_context);
            Categories = new GenericRepository<Category>(_context);
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
