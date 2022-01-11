using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class SpecialtysControllerUnitTest
    {
        Core db = new Core();
        SpecialtysController specObj = new SpecialtysController();
        [TestMethod]
        public void GetSpecialtys_GetDbData_trueReturned()
        {
            //Arrange
            specObj = new SpecialtysController();
            //Act
            bool result = specObj.GetSpecialtys().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewSpecialtys_AddingCorrectData_trueReturned()
        {
            //Arrange
            specObj = new SpecialtysController();
            string specialysName = "Построение мостов";
            string specialysCode = "ПМ-28";
            int countBefore = specObj.GetSpecialtys().Count();
            //Act
            bool result = specObj.AddNewSpecialtys(specialysName, specialysCode);
            specObj = new SpecialtysController();
            int countAfter = specObj.GetSpecialtys().Count();
            if (countAfter != countBefore + 1)
            {
                result = false;
            }
            db = new Core();
            Specialtys addedCharity = db.context.Specialtys.Where
                (x => x.specialty_code == specialysCode &&  x.specialty_name == specialysName)
                .FirstOrDefault();
            db.context.Specialtys.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewSpecialtys_AddingNullData_ExceptionReturned()
        {
            //Arrange
            specObj = new SpecialtysController();
            string specialysName = null;
            string specialysCode = null;
            //Act
            specObj = new SpecialtysController();
            void actAction() => specObj.AddNewSpecialtys(specialysName, specialysCode);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void UpdateSpecialtys_EdititingCorrectData_trueReturned()
        {
            //Arrange
            specObj = new SpecialtysController();
            string specialysName = "Построение мостов";
            string specialysCode = "ПМ-28";
            bool result = specObj.AddNewSpecialtys(specialysName, specialysCode);
            Specialtys editableCurriculum = specObj.GetSpecialtys().Where(x => x.specialty_code == specialysCode && x.specialty_name == specialysName).FirstOrDefault();
            int addedId = editableCurriculum.id_specialty;
            specialysName = "Построение дорог";
            specialysCode = "ПД-28";
            //Act
            specObj = new SpecialtysController();
            result = specObj.UpdateSpecialtys(specialysName, specialysCode, editableCurriculum);

            if (specObj.GetSpecialtys().Where(x => x.id_specialty == addedId).FirstOrDefault().specialty_code != specialysCode || specObj.GetSpecialtys().Where(x => x.id_specialty == addedId).FirstOrDefault().specialty_name != specialysName)
            {
                result = false;
            }

            db = new Core();
            Specialtys addedCharity = db.context.Specialtys.Where
                (x => x.id_specialty == addedId)
                .FirstOrDefault();
            db.context.Specialtys.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateSpecialtys_EdititingNullData_ExceptionReturned()
        {
            //Arrange
            specObj = new SpecialtysController();
            string specialysName = "Построение мостов";
            string specialysCode = "ПМ-28";
            bool result = specObj.AddNewSpecialtys(specialysName, specialysCode);
            Specialtys editableCurriculum = specObj.GetSpecialtys().Where(x => x.specialty_code == specialysCode && x.specialty_name == specialysName).FirstOrDefault();
            int addedId = editableCurriculum.id_specialty;
            specialysName = null;
            specialysCode = null;
            //Act
            specObj = new SpecialtysController();
            void actAction() => specObj.UpdateSpecialtys(specialysName, specialysCode, editableCurriculum);
            db = new Core();
            Specialtys addedCharity = db.context.Specialtys.Where
               (x => x.id_specialty == addedId)
               .FirstOrDefault();
            db.context.Specialtys.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void DropSpecialtys_AddingCorrectData_trueReturned()
        {
            //Arrange
            db = new Core();
            specObj = new SpecialtysController();
            string specialysName = "Построение мостов";
            string specialysCode = "ПМ-28";
            bool result = specObj.AddNewSpecialtys(specialysName, specialysCode);
            int countBefore = specObj.GetSpecialtys().Count();
            //Act          
            specObj = new SpecialtysController();
            Specialtys addedCharity = db.context.Specialtys.Where(x => x.specialty_code == specialysCode && x.specialty_name == specialysName).FirstOrDefault();
            specObj.DropSpecialtys(addedCharity);
            db.context.SaveChanges();
            int countAfter = specObj.GetSpecialtys().Count();
            if (countAfter != countBefore - 1)
            {
                result = false;

            }
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DropSpecialtys_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            specObj = new SpecialtysController();
            string specialysName = "Построение мостов2";
            string specialysCode = "ПМ-282";
            int countBefore = specObj.GetSpecialtys().Count();
            //Act          
            specObj = new SpecialtysController();
            Specialtys addedCharity = db.context.Specialtys.Where(x => x.specialty_code == specialysCode && x.specialty_name == specialysName).FirstOrDefault();
            void actAction() => specObj.DropSpecialtys(addedCharity);

            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
    }
}
