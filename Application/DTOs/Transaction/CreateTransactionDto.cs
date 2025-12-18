using Expense_tracker_api.Domain.Enums;

namespace Expense_tracker_api.Application.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        public Guid WalletId { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string? Note { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
