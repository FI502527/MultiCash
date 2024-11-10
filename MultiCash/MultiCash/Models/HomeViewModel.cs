namespace MultiCash.Models
{
    public class HomeViewModel
    {
        public UserViewModel User { get; set; }
        public BankViewModel Bank { get; set; }
        public HomeViewModel(UserViewModel user, BankViewModel bank)
        {
            User = user;
            Bank = bank;
        }
    }
}
