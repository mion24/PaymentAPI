namespace PaymentBlazor.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public string Doc { get; set; }
        public int ReceiverId { get; set; }
        public double Value { get; set; }
    }
}
