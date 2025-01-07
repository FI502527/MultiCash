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
    public class UserTests
    {
        [TestMethod]
        public void TryLoadingUserById()
        {
            //Arrange
            int id = 1;
            TestUserRepository testUserRepository = new TestUserRepository();
            UserService userService = new UserService(testUserRepository);

            //Act
            UserModel userModel = userService.GetUserById(id);

            //Assert
            Assert.AreEqual(id, userModel.Id);
        }
        [TestMethod]
        public void TryLogin()
        {
            //Arrange
            string email = "bob@test.com";
            string password = "123";
            TestUserRepository testUserRepository = new TestUserRepository();
            UserService userService = new UserService(testUserRepository);

            //Act
            UserModel userModel = userService.LoginCheck(email, password);

            //Assert
            Assert.AreEqual(email, userModel.Email);
            Assert.AreEqual(password, userModel.Password);
        }
        [TestMethod]
        public void TryFalseLogin()
        {
            //Arrange
            string email = "bob@test.com";
            string password = "456";
            TestUserRepository testUserRepository = new TestUserRepository();
            UserService userService = new UserService(testUserRepository);

            //Act
            UserModel userModel = userService.LoginCheck(email, password);

            //Assert
            Assert.AreEqual(null, userModel.Email);
        }
    }
}
