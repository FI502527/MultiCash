using Logic;
using Logic.Model;
using Microsoft.AspNetCore.Mvc;
using MultiCash.Models;

namespace MultiCash.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BankAccountService _bankService;
        private readonly TransactionService _transactionService;
        public TransactionController(BankAccountService bankService, TransactionService transactionService)
        {
            _bankService = bankService;
            _transactionService = transactionService;
        }
        public IActionResult Transfer()
        {

            return View();
        }

        public IActionResult TransferMoney(TransactionViewModel transaction)
        {
            BankAccountModel bankAccount = _bankService.LoadBankAccountById(transaction.BankAccountId);
            if(bankAccount.Balance < transaction.Amount)
            {
                return RedirectToAction("Transfer");
            }
            else
            {
                TransactionTypeModel transactionType = _transactionService.GetTransactionTypeByName("Transfer");
                TransactionModel transactionModel = new TransactionModel();
                transactionModel.Name = $"Transfer to bank ID {transaction.BankIdReceiver}";
                transactionModel.Amount = transaction.Amount;
                transactionModel.DateTime = DateTime.Now;
                transactionModel.BankAccountId = transaction.BankAccountId;
                transactionModel.BankIdReceiver = transaction.BankIdReceiver;
                transactionModel.Pending = false;
                transactionModel.TransactionType = transactionType;

                _transactionService.UploadTransaction(transactionModel);

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
