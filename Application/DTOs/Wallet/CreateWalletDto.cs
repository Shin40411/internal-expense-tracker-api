namespace Expense_tracker_api.Application.DTOs.Wallet
{
    public class CreateWalletDto
    {
        public string Name { get; set; } = null!;
        public decimal InitialBalance { get; set; }
    }
}
