using Logic.Model;

namespace MultiCash.Models
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public int Balance { get; set; }
        public UserViewModel User { get; set; }
        public BankTypeViewModel BankType { get; set; }
        public BankAccountViewModel() { }
        public BankAccountViewModel(int id, int balance, UserViewModel user, BankTypeViewModel bankType)
        {
            Id = id;
            Balance = balance;
            User = user;
            BankType = bankType;
        }
    }
}
