using Expense_tracker_api.Domain.Enums;

namespace Expense_tracker_api.Application.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;
        public TransactionType Type { get; set; }
    }
}
