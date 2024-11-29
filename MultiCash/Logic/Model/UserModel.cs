using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Logic.DTO;

namespace Logic.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public UserModel(int id, string email, string password, string name, string lastName)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
        }
        public UserModel(UserDTO userDTO) 
        {
            Id = userDTO.Id;
            Email = userDTO.Email;
            Password = userDTO.Password;
            Name = userDTO.Name;
            LastName = userDTO.LastName;
        }
    }
}
