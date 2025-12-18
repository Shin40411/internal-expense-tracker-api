using Expense_tracker_api.Application.DTOs.Transaction;
using Expense_tracker_api.Application.Interfaces;
using Expense_tracker_api.Domain.Entities;
using Expense_tracker_api.Domain.Enums;

namespace Expense_tracker_api.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateTransactionDto dto, Guid userId)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                WalletId = dto.WalletId,
                CategoryId = dto.CategoryId,
                Amount = dto.Amount,
                Type = dto.Type,
                Note = dto.Note,
                TransactionDate = dto.TransactionDate
            };

            await _unitOfWork.Transactions.AddAsync(transaction);

            var wallet = await _unitOfWork.Wallets.GetByIdAsync(dto.WalletId);
            if (wallet == null) throw new Exception("Wallet not found");

            wallet.Balance += dto.Type == TransactionType.INCOME
                ? dto.Amount
                : -dto.Amount;

            _unitOfWork.Wallets.Update(wallet);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByMonthAsync(Guid userId, int month, int year)
        {
            return await _unitOfWork.Transactions
                .FindAsync(t =>
                    t.UserId == userId &&
                    t.TransactionDate.Month == month &&
                    t.TransactionDate.Year == year
                );
        }
    }

}
