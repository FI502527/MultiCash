using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.DTO;
using Logic.Model;

namespace Logic
{
    public class BankService
    {
        private readonly BankAccountRepository _bankRepository;
        public BankService(BankAccountRepository bankRepository)
        {
            this._bankRepository = bankRepository;
        }
        public BankAccountModel LoadBankAccountById(int bankId)
        {
            BankAccountDTO bankDTO = _bankRepository.LoadBankAccountById(bankId);
            BankAccountModel bankModel = new BankAccountModel(bankDTO.Id, bankDTO.UserId, bankDTO.AccountType, bankDTO.Amount);
            return bankModel;
        }
    }
}