using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class SudjectsControllerUnitTest
    {
        Core db = new Core();
        SudjectsController subjObj = new SudjectsController();
        [TestMethod]
        public void GetSudjects_GetDbData_trueReturned()
        {
            //Arrange
            subjObj = new SudjectsController();
            //Act
            bool result = subjObj.GetSudjects().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewSudjects_AddingCorrectData_trueReturned()
        {
            //Arrange
            subjObj = new SudjectsController();
            string sudjectsName = "Математика";
            string sudjectsCode = "03";
            int countBefore = subjObj.GetSudjects().Count();
            //Act
            bool result = subjObj.AddNewSubjects(sudjectsName, sudjectsCode);
            subjObj = new SudjectsController();
            int countAfter = subjObj.GetSudjects().Count();
            if (countAfter != countBefore + 1)
            {
                result = false;
            }
            db = new Core();
            Sudjects addedCharity = db.context.Sudjects.Where
                (x => x.sudject_code == sudjectsCode && x.sudject_name == sudjectsName)
                .FirstOrDefault();
            db.context.Sudjects.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewSudjects_AddingNullData_ExceptionReturned()
        {
            //Arrange
            subjObj = new SudjectsController();
            string sudjectsName = null;
            string sudjectsCode = null;
            //Act
            subjObj = new SudjectsController();
            void actAction() => subjObj.AddNewSubjects(sudjectsName, sudjectsCode);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void UpdateSudjects_EdititingCorrectData_trueReturned()
        {
            //Arrange
            subjObj = new SudjectsController();
            string sudjectsName = "Математика";
            string sudjectsCode = "03";
            bool result = subjObj.AddNewSubjects(sudjectsName, sudjectsCode);
            Sudjects editableCurriculum = subjObj.GetSudjects().Where(x => x.sudject_code == sudjectsCode && x.sudject_name == sudjectsName).FirstOrDefault();
            int addedId = editableCurriculum.id_sudject;
            sudjectsName = "Информатика";
            sudjectsCode = "03.22";
            //Act
            subjObj = new SudjectsController();
            result = subjObj.UpdateSubjects(sudjectsName, sudjectsCode, editableCurriculum);

            if (subjObj.GetSudjects().Where(x => x.id_sudject == addedId).FirstOrDefault().sudject_code != sudjectsCode || subjObj.GetSudjects().Where(x => x.id_sudject == addedId).FirstOrDefault().sudject_name != sudjectsName)
            {
                result = false;
            }

            db = new Core();
            Sudjects addedCharity = db.context.Sudjects.Where
                (x => x.id_sudject == addedId)
                .FirstOrDefault();
            db.context.Sudjects.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateSudjects_EdititingNullData_ExceptionReturned()
        {
            //Arrange
            subjObj = new SudjectsController();
            string sudjectsName = "Математика";
            string sudjectsCode = "03";
            bool result = subjObj.AddNewSubjects(sudjectsName, sudjectsCode);
            Sudjects editableCurriculum = subjObj.GetSudjects().Where(x => x.sudject_code == sudjectsCode && x.sudject_name == sudjectsName).FirstOrDefault();
            int addedId = editableCurriculum.id_sudject;
            sudjectsName = null;
            sudjectsCode = null;
            //Act
            subjObj = new SudjectsController();
            void actAction() => subjObj.UpdateSubjects(sudjectsName, sudjectsCode, editableCurriculum);
            db = new Core();
            Sudjects addedCharity = db.context.Sudjects.Where
               (x => x.id_sudject == addedId)
               .FirstOrDefault();
            db.context.Sudjects.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void DropSudjects_AddingCorrectData_trueReturned()
        {
            //Arrange
            subjObj = new SudjectsController();
            string sudjectsName = "Математика";
            string sudjectsCode = "03";
            bool result = subjObj.AddNewSubjects(sudjectsName, sudjectsCode);
            int countBefore = subjObj.GetSudjects().Count();
            //Act          
            subjObj = new SudjectsController();
            Sudjects addedCharity = db.context.Sudjects.Where(x => x.sudject_code == sudjectsCode && x.sudject_name == sudjectsName).FirstOrDefault();
            subjObj.DropSudjects(addedCharity);
            db.context.SaveChanges();
            int countAfter = subjObj.GetSudjects().Count();
            if (countAfter != countBefore - 1)
            {
                result = false;

            }
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DropSudjects_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            subjObj = new SudjectsController();
            string sudjectsName = "Математика22";
            string sudjectsCode = "0322";
            int countBefore = subjObj.GetSudjects().Count();
            //Act          
            subjObj = new SudjectsController();
            Sudjects addedCharity = db.context.Sudjects.Where(x => x.sudject_code == sudjectsCode && x.sudject_name == sudjectsName).FirstOrDefault();
            void actAction() => subjObj.DropSudjects(addedCharity);

            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
    }
}
