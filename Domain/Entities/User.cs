namespace Expense_tracker_api.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? FullName { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
