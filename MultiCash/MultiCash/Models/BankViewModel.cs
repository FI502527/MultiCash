using Logic.Model;

namespace MultiCash.Models
{
    public class BankViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountType { get; set; }
        public int Amount { get; set; }
        public BankViewModel() { }
        public BankViewModel(int id, int userId, string accountType, int amount)
        {
            Id = id;
            UserId = userId;
            AccountType = accountType;
            Amount = amount;
        }

        public BankViewModel(BankAccountModel bankModel)
        {
            Id = bankModel.Id;
            UserId = bankModel.UserId;
            AccountType = bankModel.AccountType;
            Amount = bankModel.Amount;
        }
    }
}
