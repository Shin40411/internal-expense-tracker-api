using Expense_tracker_api.Application.DTOs.Category;
using Expense_tracker_api.Domain.Entities;

namespace Expense_tracker_api.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync(Guid userId, string type);
        Task<Category> CreateAsync(CreateCategoryDto dto, Guid userId);
    }
}
