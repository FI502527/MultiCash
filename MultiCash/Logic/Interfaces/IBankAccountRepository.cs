using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTO;
using Logic.Model;

namespace Logic.Interfaces
{
    public interface IBankAccountRepository
    {
        BankAccountDTO LoadBankAccountById(int bankId);
        List<BankAccountDTO> LoadBankAccountsByUserId(int userId);
        void AddBankAccount(BankAccountDTO bankDTO);
        public void UpdateBankBalance(BankAccountDTO bankDTO);
        public BankTypeDTO GetBankTypeById(int bankTypeId);
        public BankTypeDTO GetBankTypeByName(string bankTypeName);
    }
}
