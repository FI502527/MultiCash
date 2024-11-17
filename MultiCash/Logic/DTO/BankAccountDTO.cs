using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class BankAccountDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountType { get; set; }
        public int Amount { get; set; }
        public BankAccountDTO() { }
        public BankAccountDTO(int id, int userId, string accountType, int amount)
        {
            Id = id;
            UserId = userId;
            AccountType = accountType;
            Amount = amount;
        }
    }
}
