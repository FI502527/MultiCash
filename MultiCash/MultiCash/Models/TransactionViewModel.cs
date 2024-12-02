namespace MultiCash.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int BankAccountId { get; set; }
        public int BankIdReceiver { get; set; }
        public bool Pending { get; set; }
        public TransactionTypeViewModel TransactionType { get; set; }
    }
}
