namespace MultiCash.Models
{
    public class HomeViewModel
    {
        public UserViewModel User { get; set; }
        public List<BankViewModel> Banks { get; set; }
        public HomeViewModel(UserViewModel user, List<BankViewModel> banks)
        {
            User = user;
            Banks = banks;
        }
    }
}
