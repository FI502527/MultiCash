using Logic.DTO;
using Logic.Interfaces;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        public TransactionService(ITransactionRepository transactionRepository, IBankAccountRepository bankAccountRepository)
        {
            _transactionRepository = transactionRepository;
            _bankAccountRepository = bankAccountRepository;
        }
        public TransactionTypeModel GetTransactionTypeByName(string name)
        {
            TransactionTypeModel transactionType = new TransactionTypeModel(_transactionRepository.GetTransactionTypeByName(name));
            return transactionType;
        }
        public void UploadTransaction(TransactionModel transaction)
        {
            TransactionDTO transactionDTO = new TransactionDTO(transaction);
            _transactionRepository.UploadTransaction(transactionDTO);
            
            BankAccountDTO currentUserBank = _bankAccountRepository.LoadBankAccountById(transaction.BankAccountId);
            currentUserBank.Balance = currentUserBank.Balance - transaction.Amount;
            _bankAccountRepository.UpdateBankBalance(currentUserBank);

            BankAccountDTO newBankCheck = _bankAccountRepository.LoadBankAccountById(transaction.BankIdReceiver);
            if(newBankCheck.Balance != null)
            {
                newBankCheck.Balance = newBankCheck.Balance + transaction.Amount;
                _bankAccountRepository.UpdateBankBalance(newBankCheck);
            }
        }
    }
}
