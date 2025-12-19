namespace Expense_tracker_api.Application.DTOs.Auth
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
