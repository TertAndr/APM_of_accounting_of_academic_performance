using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class TeachersControllerUnitTest
    {
        Core db = new Core();
        TeachersController teashObj = new TeachersController();
        UsersController userObj = new UsersController();
        [TestMethod]
        public void GetTeachers_GetDbData_trueReturned()
        {
            //Arrange
            teashObj = new TeachersController();
            //Act
            bool result = teashObj.GetTeachers().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }    

        [TestMethod]
        public void AddNewTeachers_AddingCorrectData_trueReturned()
        {
            //Arrange
            teashObj = new TeachersController();
           userObj = new UsersController();
            string teacherFname = "Валов";
            string teacherName = "Семен";
            string teacherPatronomic = "Васильевич";
            byte[] avatarImage = null;
            string userLogin = "User66";
            string userPassword = "User66";
            int userRole = 2;
            int idUser = userObj.AddNewUser(userLogin, userPassword, userRole);
            int countBefore = teashObj.GetTeachers().Count();
            //Act
            bool result = teashObj.AddNewTeasher(teacherFname, teacherName, teacherPatronomic, avatarImage, idUser);
            teashObj = new TeachersController();
            int countAfter = teashObj.GetTeachers().Count();
            if (countAfter != countBefore + 1)
            {
                result = false;
            }
            db = new Core();
            Teachers addedCharity = db.context.Teachers.Where
                (x => x.teacher_fname== teacherFname && x.teacher_name == teacherName && x.teacher_patronomic == teacherPatronomic)
                .FirstOrDefault();
            db.context.Teachers.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewTeachers_AddingNullData_ExceptionReturned()
        {
            //Arrange
            teashObj = new TeachersController();
            userObj = new UsersController();
            string teacherFname = null;
            string teacherName = null;
            string teacherPatronomic = null;
            byte[] avatarImage = null;
            int idUser = 0;
            //Act
            teashObj = new TeachersController();
            void actAction() => teashObj.AddNewTeasher(teacherFname, teacherName, teacherPatronomic, avatarImage, idUser);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void UpdateTeachers_EdititingCorrectData_trueReturned()
        {
            //Arrange
            teashObj = new TeachersController();
            userObj = new UsersController();
            string teacherFname = "Сидоров";
            string teacherName = "Иван";
            string teacherPatronomic = "Васильевич";
            byte[] avatarImage = null;
            string userLogin = "User66";
            string userPassword = "User66";
            int userRole = 2;
            int idUser = userObj.AddNewUser(userLogin, userPassword, userRole);
            bool result = teashObj.AddNewTeasher(teacherFname, teacherName, teacherPatronomic, avatarImage, idUser);
            Teachers editableCurriculum = teashObj.GetTeachers().Where(x => x.teacher_fname == teacherFname && x.teacher_name == teacherName && x.teacher_patronomic == teacherPatronomic).FirstOrDefault();
            int addedId = editableCurriculum.id_teacher;
           teacherFname = "Петров";
            teacherName = "Генадий";
            teacherPatronomic = "Петрович";
            //Act
            teashObj = new TeachersController();
            result = teashObj.UpdateTeasher(teacherFname, teacherName, teacherPatronomic, avatarImage, editableCurriculum);

            if (teashObj.GetTeachers().Where(x => x.id_teacher == addedId).FirstOrDefault().teacher_fname != teacherFname || teashObj.GetTeachers().Where(x => x.id_teacher == addedId).FirstOrDefault().teacher_name != teacherName || teashObj.GetTeachers().Where(x => x.id_teacher == addedId).FirstOrDefault().teacher_patronomic != teacherPatronomic)
            {
                result = false;
            }

            db = new Core();
            Teachers addedCharity = db.context.Teachers.Where
                (x => x.teacher_fname == teacherFname && x.teacher_name == teacherName && x.teacher_patronomic == teacherPatronomic)
                .FirstOrDefault();
            db.context.Teachers.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
       
        [TestMethod]
        public void DropTeachers_AddingCorrectData_trueReturned()
        {
            //Arrange
            teashObj = new TeachersController();
            userObj = new UsersController();
            string teacherFname = "Сидоров";
            string teacherName = "Иван";
            string teacherPatronomic = "Васильевич";
            byte[] avatarImage = null;
            string userLogin = "User66";
            string userPassword = "User66";
            int userRole = 2;
            int idUser = userObj.AddNewUser(userLogin, userPassword, userRole);
            bool result = teashObj.AddNewTeasher(teacherFname, teacherName, teacherPatronomic, avatarImage, idUser);
            int countBefore = teashObj.GetTeachers().Count();
            //Act          
            teashObj = new TeachersController();
            Teachers addedCharity = db.context.Teachers.Where(x => x.teacher_fname == teacherFname && x.teacher_name == teacherName && x.teacher_patronomic == teacherPatronomic).FirstOrDefault();
            teashObj.DropTeachers(addedCharity);
            db.context.SaveChanges();
            int countAfter = teashObj.GetTeachers().Count();
            if (countAfter != countBefore - 1)
            {
                result = false;

            }
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DropTeachers_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            teashObj = new TeachersController();
            userObj = new UsersController();
            string teacherFname = "Сидоров78";
            string teacherName = "Иван78";
            string teacherPatronomic = "Васильевич78";
            byte[] avatarImage = null;
            string userLogin = "User66";
            string userPassword = "User66";
            int userRole = 2;
            int idUser = userObj.AddNewUser(userLogin, userPassword, userRole);
            int countBefore = teashObj.GetTeachers().Count();
            //Act          
            teashObj = new TeachersController();
            Teachers addedCharity = db.context.Teachers.Where(x => x.teacher_fname == teacherFname && x.teacher_name == teacherName && x.teacher_patronomic == teacherPatronomic).FirstOrDefault();
            void actAction() => teashObj.DropTeachers(addedCharity);

            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
    }
}
