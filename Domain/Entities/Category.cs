using Expense_tracker_api.Domain.Enums;

namespace Expense_tracker_api.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public TransactionType Type { get; set; }
    }
}
