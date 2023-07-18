namespace PaymentAPI.ResultViewModel.Transactions
{
    public class TransactionViewModel
    {
        public int SenderId { get; set; }
        public int IdReceiver { get; set; }
        public decimal DocValue { get; set; }
    }
}
