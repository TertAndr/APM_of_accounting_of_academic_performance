using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class GroupsControllerUnitTest
    {
        Core db = new Core();
        GroupsController groupObj = new GroupsController();
        [TestMethod]
        public void GetGroups_GetDbData_trueReturned()
        {
            //Arrange
            groupObj = new GroupsController();
            //Act
            bool result = groupObj.GetGroups().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewGroups_AddingCorrectData_trueReturned()
        {
            //Arrange
            groupObj = new GroupsController();
            string groupName = "Группа";           
            int countBefore = groupObj.GetGroups().Count();
            //Act
            bool result = groupObj.AddNewGroups(groupName);
            groupObj = new GroupsController();
            int countAfter = groupObj.GetGroups().Count();
            if (countAfter != countBefore + 1)
            {
                result = false;
            }
            db = new Core();
            Groups addedCharity = db.context.Groups.Where
                (x => x.groups_name== groupName)
                .FirstOrDefault();
            db.context.Groups.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddNewGroups_AddingNullData_ExceptionReturned()
        {
            //Arrange
            groupObj = new GroupsController();
            string groupName = null;
            //Act
            groupObj = new GroupsController();
            void actAction() => groupObj.AddNewGroups(groupName);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void UpdateGroups_EdititingCorrectData_trueReturned()
        {
            //Arrange
            groupObj = new GroupsController();
            string groupName = "Группа";
            bool result = groupObj.AddNewGroups(groupName);
            Groups editableCurriculum = groupObj.GetGroups().Where(x => x.groups_name == groupName).FirstOrDefault();
            int addedId = editableCurriculum.id_group;
            groupName = "ГруппаИзменена";
            //Act
            groupObj = new GroupsController();
            result = groupObj.UpdateGroups(groupName,editableCurriculum);

            if (groupObj.GetGroups().Where(x => x.id_group == addedId).FirstOrDefault().groups_name != groupName)
            {
                result = false;
            }

            db = new Core();
            Groups addedCharity = db.context.Groups.Where
                (x => x.id_group == addedId)
                .FirstOrDefault();
            db.context.Groups.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateGroups_EdititingNullData_ExceptionReturned()
        {
            //Arrange
            groupObj = new GroupsController();
            string groupName = "Группа";
            bool result = groupObj.AddNewGroups(groupName);
            Groups editableCurriculum = groupObj.GetGroups().Where(x => x.groups_name == groupName).FirstOrDefault();
            int addedId = editableCurriculum.id_group;
            groupName = null;
            //Act
            groupObj = new GroupsController();
            void actAction() => groupObj.UpdateGroups(groupName, editableCurriculum);
            db = new Core();
            Groups addedCharity = db.context.Groups.Where
               (x => x.id_group == addedId)
               .FirstOrDefault();
            db.context.Groups.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void DropGroups_AddingCorrectData_trueReturned()
        {
            //Arrange
            db = new Core();
            groupObj = new GroupsController();
            string groupName = "Группа";
            bool result = groupObj.AddNewGroups(groupName);
            int countBefore = groupObj.GetGroups().Count();
            //Act          
            groupObj = new GroupsController();
            Groups addedCharity = db.context.Groups.Where(x => x.groups_name == groupName).FirstOrDefault();
            groupObj.DropGroups(addedCharity);
            db.context.SaveChanges();
            int countAfter = groupObj.GetGroups().Count();
            if (countAfter != countBefore - 1)
            {
                result = false;

            }
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DropGroups_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            db = new Core();
            groupObj = new GroupsController();
            string groupName = "Группа2";
            int countBefore = groupObj.GetGroups().Count();
            //Act          
            groupObj = new GroupsController();
            Groups addedCharity = db.context.Groups.Where(x => x.groups_name == groupName).FirstOrDefault();
            void actAction() => groupObj.DropGroups(addedCharity);

            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

    }
}
