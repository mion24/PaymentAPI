namespace PaymentBlazor.Models
{
    public class Transactions
    {
        public Transactions()
        {
           Doc = Guid.NewGuid();
        }
        public int Id { get; set; }
        public Guid Doc { get; set; }
        public string ReceiverKey { get; set; }
        public double Value { get; set; }
        public string Note { get; set; }
    }
}
