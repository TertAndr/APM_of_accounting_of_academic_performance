using APM_of_accounting_of_academic_performance.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APM_of_accounting_of_academic_performance.Models;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class Curriculum_in_the_specialtysControllerUnitTest
    {
        Core db = new Core();
        Curriculum_in_the_specialtysController currObj = new Curriculum_in_the_specialtysController();
        [TestMethod]
        public void GetCurriculum_in_the_specialtys_GetDbData_trueReturned()
        {
            //Arrange
            currObj = new Curriculum_in_the_specialtysController();
            //Act
            bool result = currObj.GetCurriculum_in_the_specialtys().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCurriculum_in_the_specialtysYears_GetDbData_trueReturned()
        {
            //Arrange
            int selectedYears = 21;
            currObj = new Curriculum_in_the_specialtysController();
            //Act
            bool result = currObj.GetCurriculum_in_the_specialtysYears(selectedYears).Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCurriculum_in_the_specialtysYears_GetDbData_ExceptionReturned()
        {
            //Arrange
            currObj = new Curriculum_in_the_specialtysController();
            int selectedYears = -21;
            //Act
            Action actAction = () => currObj.GetCurriculum_in_the_specialtysYears(selectedYears).Count();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void GetCurriculum_in_the_specialtysSpecialtys_GetDbData_trueReturned()
        {
            //Arrange
            int selectedSpecial = 1;
            currObj = new Curriculum_in_the_specialtysController();
            //Act
            bool result = currObj.GetCurriculum_in_the_specialtysSpecialtys(selectedSpecial).Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCurriculum_in_the_specialtysSpecialtys_GetDbData_ExceptionReturned()
        {
            //Arrange
            currObj = new Curriculum_in_the_specialtysController();
            int selectedSpecial = -1;
            //Act
            Action actAction = () => currObj.GetCurriculum_in_the_specialtysSpecialtys(selectedSpecial).Count();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void AddNewCurriculum_in_the_specialtysSpecialtyst_AddingCorrectData_trueReturned()
        {
            //Arrange
            currObj = new Curriculum_in_the_specialtysController();
            int specialtysId = 1;
            int sudjectsId = 1;
            int currentAllhours = 100;
            int currentSudjectHoursTheory = 50;
            int currentSudjectHoursPractice = 25;
            int currentSudjectHourscourseDesign = 25;
            int currentSemesterNumbers = 1;
            int currentYearOfStudy = 21;
            string currentCode = "20.32";
            int countBefore = currObj.GetCurriculum_in_the_specialtys().Count();
            //Act
            bool result = currObj.AddNewCurriculums(specialtysId, sudjectsId, currentAllhours,  currentSudjectHoursTheory,  currentSudjectHoursPractice,
             currentSudjectHourscourseDesign,  currentSemesterNumbers,  currentYearOfStudy,  currentCode);
             currObj = new Curriculum_in_the_specialtysController();
            int countAfter = currObj.GetCurriculum_in_the_specialtys().Count();
            if (countAfter != countBefore + 1)
            {
                result = false;
            }
            db = new Core();
            Curriculum_in_the_specialtys addedCharity = db.context.Curriculum_in_the_specialtys.Where
                (x => x.id_specialty == specialtysId && x.id_sudject == sudjectsId)
                .FirstOrDefault();
            db.context.Curriculum_in_the_specialtys.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewCurriculum_in_the_specialtysSpecialtys_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            currObj = new Curriculum_in_the_specialtysController();
            int specialtysId = -10;
            int sudjectsId = -10;
            int currentAllhours = 100;
            int currentSudjectHoursTheory = 50;
            int currentSudjectHoursPractice = 25;
            int currentSudjectHourscourseDesign = 25;
            int currentSemesterNumbers = 1;
            int currentYearOfStudy = 21;
            string currentCode = "20.32";
            int countBefore = currObj.GetCurriculum_in_the_specialtys().Count();
            //Act
            currObj = new Curriculum_in_the_specialtysController();
            void actAction() => currObj.AddNewCurriculums(specialtysId, sudjectsId, currentAllhours, currentSudjectHoursTheory, currentSudjectHoursPractice,
             currentSudjectHourscourseDesign, currentSemesterNumbers, currentYearOfStudy, currentCode);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void UpdateCurriculum_in_the_specialtysSpecialtys_EdititingCorrectData_trueReturned()
        {
            //Arrange
            currObj = new Curriculum_in_the_specialtysController();
            int specialtysId = 1;
            int sudjectsId = 1;
            int currentAllhours = 100;
            int currentSudjectHoursTheory = 50;
            int currentSudjectHoursPractice = 25;
            int currentSudjectHourscourseDesign = 25;
            int currentSemesterNumbers = 1;
            int currentYearOfStudy = 21;
            string currentCode = "20.32";
            bool result = currObj.AddNewCurriculums(specialtysId, sudjectsId, currentAllhours, currentSudjectHoursTheory, currentSudjectHoursPractice,
             currentSudjectHourscourseDesign, currentSemesterNumbers, currentYearOfStudy, currentCode);
            Curriculum_in_the_specialtys editableCurriculum = currObj.GetCurriculum_in_the_specialtys().Where(x => x.id_specialty == specialtysId && x.id_sudject == sudjectsId).FirstOrDefault();
            int addedId = editableCurriculum.id_curriculum_in_the_specialty;
             currentAllhours = 150;
             currentSudjectHoursTheory = 100;
            //Act
            currObj = new Curriculum_in_the_specialtysController();
            result = currObj.UpdateCurriculums(specialtysId, sudjectsId, currentAllhours, currentSudjectHoursTheory, currentSudjectHoursPractice,
             currentSudjectHourscourseDesign, currentSemesterNumbers, currentYearOfStudy, currentCode, editableCurriculum);

            if (currObj.GetCurriculum_in_the_specialtys().Where(x => x.id_curriculum_in_the_specialty == addedId).FirstOrDefault().id_specialty != specialtysId || currObj.GetCurriculum_in_the_specialtys().Where(x => x.id_curriculum_in_the_specialty == addedId).FirstOrDefault().id_sudject != sudjectsId)
            {
                result = false;
            }

            db = new Core();
            Curriculum_in_the_specialtys addedCharity = db.context.Curriculum_in_the_specialtys.Where
                (x => x.id_curriculum_in_the_specialty == addedId)
                .FirstOrDefault();
            db.context.Curriculum_in_the_specialtys.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateCurriculum_in_the_specialtysSpecialtys_EdititingExceptionDataData_ExceptionReturned()
        {
            //Arrange
            currObj = new Curriculum_in_the_specialtysController();
            int specialtysId = 1;
            int sudjectsId = 1;
            int currentAllhours = 100;
            int currentSudjectHoursTheory = 50;
            int currentSudjectHoursPractice = 25;
            int currentSudjectHourscourseDesign = 25;
            int currentSemesterNumbers = 1;
            int currentYearOfStudy = 21;
            string currentCode = "20.32";
            bool result = currObj.AddNewCurriculums(specialtysId, sudjectsId, currentAllhours, currentSudjectHoursTheory, currentSudjectHoursPractice,
             currentSudjectHourscourseDesign, currentSemesterNumbers, currentYearOfStudy, currentCode);
            Curriculum_in_the_specialtys editableCurriculum = currObj.GetCurriculum_in_the_specialtys().Where(x => x.id_specialty == specialtysId && x.id_sudject == sudjectsId).FirstOrDefault();
            int addedId = editableCurriculum.id_curriculum_in_the_specialty;
            specialtysId = -1;
            sudjectsId = -1;
            //Act
            currObj = new Curriculum_in_the_specialtysController();
            void actAction() => currObj.UpdateCurriculums(specialtysId, sudjectsId, currentAllhours, currentSudjectHoursTheory, currentSudjectHoursPractice,
             currentSudjectHourscourseDesign, currentSemesterNumbers, currentYearOfStudy, currentCode, editableCurriculum);
            db = new Core();
            Curriculum_in_the_specialtys addedCharity = db.context.Curriculum_in_the_specialtys.Where
                (x => x.id_curriculum_in_the_specialty == addedId)
                .FirstOrDefault();
            db.context.Curriculum_in_the_specialtys.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void DropCurriculum_in_the_specialtysSpecialtys_AddingCorrectData_trueReturned()
        {
            //Arrange
            db = new Core();
            currObj = new Curriculum_in_the_specialtysController();
            int specialtysId = 1;
            int sudjectsId = 1;
            int currentAllhours = 100;
            int currentSudjectHoursTheory = 50;
            int currentSudjectHoursPractice = 25;
            int currentSudjectHourscourseDesign = 25;
            int currentSemesterNumbers = 1;
            int currentYearOfStudy = 21;
            string currentCode = "20.32";
            bool result = currObj.AddNewCurriculums(specialtysId, sudjectsId, currentAllhours, currentSudjectHoursTheory, currentSudjectHoursPractice,
             currentSudjectHourscourseDesign, currentSemesterNumbers, currentYearOfStudy, currentCode);
            int countBefore = currObj.GetCurriculum_in_the_specialtys().Count();
            //Act          
            currObj = new Curriculum_in_the_specialtysController();
            Curriculum_in_the_specialtys addedCharity = db.context.Curriculum_in_the_specialtys.Where(x => x.id_specialty == specialtysId && x.id_sudject == sudjectsId).FirstOrDefault();
            currObj.DropCurriculum_in_the_specialtys(addedCharity);
            db.context.SaveChanges();
            int countAfter = currObj.GetCurriculum_in_the_specialtys().Count();
            if (countAfter != countBefore - 1)
            {
                result = false;

            }
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DropCurriculum_in_the_specialtysSpecialtys_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            db = new Core();
            currObj = new Curriculum_in_the_specialtysController();
            int specialtysId = 100;
            int sudjectsId = 100;
            int countBefore = currObj.GetCurriculum_in_the_specialtys().Count();
            //Act          
            currObj = new Curriculum_in_the_specialtysController();
            Curriculum_in_the_specialtys addedCharity = db.context.Curriculum_in_the_specialtys.Where(x => x.id_specialty == specialtysId && x.id_sudject == sudjectsId).FirstOrDefault();
            void actAction() => currObj.DropCurriculum_in_the_specialtys(addedCharity);

            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }



    }
}
