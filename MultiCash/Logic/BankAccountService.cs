using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Model;
using Logic.DTO;

namespace Logic
{
    public class BankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        public BankAccountService(IBankAccountRepository bankRepository)
        {
            this._bankAccountRepository = bankRepository;
        }
        public BankAccountModel LoadBankAccountById(int bankId)
        {
            BankAccountDTO bankDTO = _bankAccountRepository.LoadBankAccountById(bankId);
            BankAccountModel bankModel = new BankAccountModel(bankDTO);
            return bankModel;
        }
        public List<BankAccountModel> LoadBankAccountsByUserId(int userId)
        {
            List<BankAccountDTO> bankDTOs = _bankAccountRepository.LoadBankAccountsByUserId(userId);
            List<BankAccountModel> bankModels = new List<BankAccountModel>();
            foreach(BankAccountDTO bankDTO  in bankDTOs)
            {
                BankAccountModel bankModel = new BankAccountModel(bankDTO);
                bankModels.Add(bankModel);
            }
            return bankModels;
        }
        public void AddBankAccount(BankAccountModel bankModel)
        {
            BankAccountDTO bankDTO = new BankAccountDTO(bankModel.Id, bankModel.UserId, bankModel.AccountType, bankModel.Amount);
            _bankAccountRepository.AddBankAccount(bankDTO);
            return;
        }
    }
}