using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class BankAccountModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountType { get; set; }
        public int Amount { get; set; }
        public BankAccountModel(int id, int userId, string accountType, int amount)
        {
            Id = id;
            UserId = userId;
            AccountType = accountType;
            Amount = amount;
        }
        public BankAccountModel(BankAccountDTO bankAccountDTO)
        {
            Id = bankAccountDTO.Id;
            UserId = bankAccountDTO.UserId;
            AccountType = bankAccountDTO.AccountType;
            Amount = bankAccountDTO.Amount;
        }
    }
}
