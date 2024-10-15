namespace MultiCash.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserViewModel(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}
