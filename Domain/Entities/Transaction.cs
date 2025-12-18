using Expense_tracker_api.Domain.Enums;

namespace Expense_tracker_api.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid WalletId { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string? Note { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
