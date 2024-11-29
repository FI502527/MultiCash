using Logic.Model;

namespace MultiCash.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public UserViewModel(int id, string email, string password, string name, string lastName)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
        }
        public UserViewModel(UserModel user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            LastName = user.LastName;
        }
        public UserViewModel() { }
    }
}
