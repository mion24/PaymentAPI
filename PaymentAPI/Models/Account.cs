namespace PaymentAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public User AccountOwner { get; set; } = null!;
        public int AccountOwnerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal Balance { get; set; }

    }
}
