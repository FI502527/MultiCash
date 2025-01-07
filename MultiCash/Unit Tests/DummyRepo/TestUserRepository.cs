using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.DummyRepo
{
    public class TestUserRepository : IUserRepository
    {
        public UserDTO LoadUserById(int id)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = 1,
                Email = "bob@test.com",
                Password = "123",
                Name = "Bob",
                LastName = "Jansen"
            };
            return userDTO;
        }
        public UserDTO LoginCheck(string email, string password)
        {
            if(email == "bob@test.com" &&  password == "123")
            {
                UserDTO userDTO = new UserDTO
                {
                    Id = 1,
                    Email = "bob@test.com",
                    Password = "123",
                    Name = "Bob",
                    LastName = "Jansen"
                };
                return userDTO;
            }
            else
            {
                UserDTO userDTO = new UserDTO();
                return userDTO;
            }
        }
    }
}
