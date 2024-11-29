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
        public int Balance { get; set; }
        public UserModel User { get; set; }
        public BankTypeModel BankType { get; set; }
        public BankAccountModel(int id, int balance, UserModel user, BankTypeModel bankType)
        {
            Id = id;
            Balance = balance;
            User = user;
            BankType = bankType;
        }
        public BankAccountModel() { }
        public BankAccountModel(BankAccountDTO bankAccountDTO)
        {
            Id = bankAccountDTO.Id;
            Balance = bankAccountDTO.Balance;
        }
        public BankAccountModel(BankAccountDTO bankAccountDTO, UserModel user)
        {
            Id = bankAccountDTO.Id;
            Balance = bankAccountDTO.Balance;
            User = user;
        }
        public BankAccountModel(BankAccountDTO bankAccountDTO, UserModel user, BankTypeModel bankType)
        {
            Id = bankAccountDTO.Id;
            Balance = bankAccountDTO.Balance;
            User = user;
            BankType = bankType;
        }
    }
}