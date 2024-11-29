using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IUserRepository
    {
        UserDTO LoadUserById(int id);
        UserDTO LoginCheck(string username, string password);
    }
}
