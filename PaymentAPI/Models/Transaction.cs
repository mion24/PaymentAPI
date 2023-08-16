namespace PaymentAPI.Models
{
    public class Transaction
    {
        public Transaction()
        {
            MovDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Doc { get; set; }
        public int SenderId { get; set; }
        public int IdReceiver{ get; set; }
        public decimal DocValue { get; set; }
        public DateTime MovDate { get; set; }
    }
}
