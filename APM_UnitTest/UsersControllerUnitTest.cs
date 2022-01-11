using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class UsersControllerUnitTest
    {     
        Core db = new Core();
        UsersController userObj = new UsersController();
        [TestMethod]
        public void GetUsers_GetDbData_trueReturned()
        {
            //Arrange
            userObj = new UsersController();
            //Act
            bool result = userObj.GetUsers().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UserAuth_AuthAdmin_oneReturned()
        {
            //Arrange
            userObj = new UsersController();
            string userLogin = "Admin1";
            string userPassword = "Admin1";
            //Act
            int role = userObj.UserAuth(userLogin, userPassword);
            //Assert
            Assert.AreEqual(role, 1);
        }

        [TestMethod]
        public void UserAuth_AuthAdmin_twoReturned()
        {
            //Arrange
            userObj = new UsersController();
            string userLogin = "User1";
            string userPassword = "User1";
            //Act
            int role = userObj.UserAuth(userLogin, userPassword);
            //Assert
            Assert.AreEqual(role, 2);
        }

        [TestMethod]
        public void UserAuth_AuthInvalid_zeroReturned()
        {
            //Arrange
            userObj = new UsersController();
            string email = "njnjnjnj";
            string password = "njnjnjnj";
            //Act
            int role = userObj.UserAuth(email, password);
            //Assert
            Assert.AreEqual(role, 0);
        }

        [TestMethod]
        public void AddNewUser_AddingCorrectData_trueReturned()
        {
            //Arrange
            userObj = new UsersController();
            string userLogin = "Users6";
            string userPassword = "Users6";
            int userRole =1;
            int countBefore = userObj.GetUsers().Count();
            bool res = true;
            //Act
            int result = userObj.AddNewUser(userLogin, userPassword, userRole);
            userObj = new UsersController();
            int countAfter = userObj.GetUsers().Count();
            if (countAfter != countBefore + 1)
            {
                res = false;
            }
            db = new Core();
            Users addedCharity = db.context.Users.Where
                (x => x.user_login == userLogin && x.user_password == userPassword && x.id_role == userRole)
                .FirstOrDefault();
            db.context.Users.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void AddNewUser_AddingNullData_ExceptionReturned()
        {
            //Arrange
            userObj = new UsersController();
            string userLogin = null ;
            string userPassword = null;
            int userRole = -1;
            //Act
            userObj = new UsersController();
            void actAction() => userObj.AddNewUser(userLogin, userPassword, userRole);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }     
    }
}
