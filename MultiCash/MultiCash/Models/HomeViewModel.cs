namespace MultiCash.Models
{
    public class HomeViewModel
    {
        public UserViewModel User { get; set; }
        public List<BankAccountViewModel> Banks { get; set; }
        public HomeViewModel(UserViewModel user, List<BankAccountViewModel> banks)
        {
            User = user;
            Banks = banks;
        }
    }
}
