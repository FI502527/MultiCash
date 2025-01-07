using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.DummyRepo
{
    public class TestBankAccountRepository : IBankAccountRepository
    {
        public BankAccountDTO LoadBankAccountById(int bankId)
        {
            BankAccountDTO bankAccount = new BankAccountDTO
            {
                Id = 1,
                Balance = 500,
                BankTypeId = 1,
                UserId =  1
            };
            return bankAccount;
        }
        public List<BankAccountDTO> LoadBankAccountsByUserId(int userId)
        {
            BankAccountDTO bank1 = new BankAccountDTO
            {
                Id = 1,
                Balance = 500,
                BankTypeId = 1,
                UserId = userId
            };
            BankAccountDTO bank2 = new BankAccountDTO
            {
                Id = 2,
                Balance = 500,
                BankTypeId = 2,
                UserId = userId
            };
            List<BankAccountDTO> bankAccounts = new List<BankAccountDTO> { bank1, bank2 };
            return bankAccounts;
        }
        public void AddBankAccount(BankAccountDTO bankDTO)
        {
            return;
        }
        public void UpdateBankBalance(BankAccountDTO bankDTO)
        {
            return;
        }
        public BankTypeDTO GetBankTypeById(int bankTypeId)
        {
            BankTypeDTO bankType = new BankTypeDTO
            {
                Id = bankTypeId,
                Name = "Debit"
            };
            return bankType;
        }
        public BankTypeDTO GetBankTypeByName(string bankTypeName)
        {
            BankTypeDTO bankType = new BankTypeDTO
            {
                Id = 1,
                Name = bankTypeName
            };
            return bankType;
        }

    }
}

