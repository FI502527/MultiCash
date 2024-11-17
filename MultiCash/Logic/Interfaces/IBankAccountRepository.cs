using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTO;

namespace Logic.Interfaces
{
    public interface IBankAccountRepository
    {
        BankAccountDTO LoadBankAccountById(int bankId);
        List<BankAccountDTO> LoadBankAccountsByUserId(int userId);
        void AddBankAccount(BankAccountDTO bankDTO);
    }
}
