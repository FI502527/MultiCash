using Logic;
using Logic.DTO;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.DummyRepo;

namespace Unit_Tests.Unit_Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void TryLoadingBankAccountWithId()
        {
            //Arrange
            int id = 1;
            TestBankAccountRepository bankRepository = new TestBankAccountRepository();
            TestUserRepository userRepository = new TestUserRepository();
            BankAccountService bankAccountService = new BankAccountService(bankRepository, userRepository);

            //Act
            BankAccountModel bankAccount = bankAccountService.LoadBankAccountById(id);
            
            //Assert
            Assert.AreEqual(id, bankAccount.Id);
        }
        [TestMethod]
        public void TryLoadingBankAccountWithUserId()
        {
            //Arrange
            int userId = 1;
            TestBankAccountRepository bankRepository = new TestBankAccountRepository();
            TestUserRepository userRepository = new TestUserRepository();
            BankAccountService bankAccountService = new BankAccountService(bankRepository, userRepository);

            //Act
            List<BankAccountModel> bankAccounts = bankAccountService.LoadBankAccountsByUserId(userId);

            //Assert
            Assert.AreEqual(userId, bankAccounts[0].User.Id);
        }
        [TestMethod]
        public void TryAddingBank()
        {
            //Arrange
            BankTypeModel bankType = new BankTypeModel
            {
                Id = 1,
                Name = "Debit"
            };
            UserModel userModel = new UserModel
            {
                Id = 1,
                Email = "bob@test.com",
                Password = "123",
                Name = "Bob",
                LastName = "Jansen"
            };
            BankAccountModel bankModel = new BankAccountModel
            {
                Id = 1,
                Balance = 500,
                User = userModel,
                BankType = bankType
            };
            TestBankAccountRepository bankRepository = new TestBankAccountRepository();
            TestUserRepository userRepository = new TestUserRepository();
            BankAccountService bankAccountService = new BankAccountService(bankRepository, userRepository);

            //Act
            bankAccountService.AddBankAccount(bankModel);

            //Assert
            // Assert.AreEqual(id, bankAccount.Id); WAT MOET IK HIER ASSERTEN?
        }
        [TestMethod]
        public void TryGettingBankType()
        {
            //Arrange
            string name = "Debit";
            TestBankAccountRepository bankRepository = new TestBankAccountRepository();
            TestUserRepository userRepository = new TestUserRepository();
            BankAccountService bankAccountService = new BankAccountService(bankRepository, userRepository);

            //Act
            BankTypeModel bankTypeModel = bankAccountService.GetBankTypeByName(name);

            //Assert
            Assert.AreEqual(name, bankTypeModel.Name);
        }
    }
}
