using Logic.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.DummyRepo;
using Logic.DTO;

namespace Unit_Tests.Unit_Tests
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void LoadTransactionTypeByName()
        {
            //Arrange
            string name = "Withdrawal";
            TestTransactionRepository transactionRepository = new TestTransactionRepository();
            TestBankAccountRepository bankAccountRepository = new TestBankAccountRepository();
            TransactionService transactionService = new TransactionService(transactionRepository, bankAccountRepository);

            //Act
            TransactionTypeModel transactionType = transactionService.GetTransactionTypeByName(name);

            //Assert
            Assert.AreEqual(name, transactionType.Name);
        }
        public void TryAddingTransaction()
        {
            //Arrange
            TransactionTypeModel transactionType = new TransactionTypeModel
            {
                Id = 1,
                Name = "Withdrawal"
            };
            TransactionModel transactionModel = new TransactionModel
            {
                Id = 1,
                Name = "McDonalds",
                Amount = 12,
                DateTime = DateTime.Now,
                BankAccountId = 1,
                BankIdReceiver = 2,
                Pending = false,
                TransactionType = transactionType
            };
            TestTransactionRepository transactionRepository = new TestTransactionRepository();
            TestBankAccountRepository bankAccountRepository = new TestBankAccountRepository();
            TransactionService transactionService = new TransactionService(transactionRepository, bankAccountRepository);

            //Act
            transactionService.UploadTransaction(transactionModel);

            //Assert
            // Assert.AreEqual(); WAT MOET IK HIER ASSERTEN???
        }
    }
}
