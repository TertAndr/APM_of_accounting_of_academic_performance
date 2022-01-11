using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class AttachmentControllerUnitTest
    {
        AttachmentController attObj = new AttachmentController();
        Core db = new Core();
        [TestMethod]
        public void GetAttachment_GetDbData_trueReturned()
        {
            //Arrange
            attObj = new AttachmentController();
            //Act
            bool result = attObj.GetAttachment().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetAttachmentUser_GetDbData_trueReturned()
        {
            //Arrange
            int Id_Profile = 2;
            attObj = new AttachmentController();
            //Act
            bool result = attObj.GetAttachmentUser(Id_Profile).Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetAttachmentUser_GetDbData_ExceptionReturned()
        {
            //Arrange
            attObj = new AttachmentController();
            int Id_Profile = -10;          
            //Act
            Action actAction = () => attObj.GetAttachmentUser(Id_Profile).Count();
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void AddNewSubject_AddingCorrectData_trueReturned()
        {
            //Arrange
            attObj = new AttachmentController();
            int teasherId = 2;
            int sudjectId = 2;
            int countBefore = attObj.GetAttachment().Count();
            //Act
            bool result = attObj.AddNewSubject(teasherId, sudjectId);
            attObj = new AttachmentController();
            int countAfter = attObj.GetAttachment().Count();
            if (countAfter != countBefore + 1)
            {
                result = false;
            }
            db = new Core();
            Attachment addedCharity = db.context.Attachment.Where
                (x => x.id_teacher == teasherId && x.id_sudject == sudjectId)
                .FirstOrDefault();
            db.context.Attachment.Remove(addedCharity);
            db.context.SaveChanges();
            //Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void AddNewSubject_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            attObj = new AttachmentController();
            int teasherId = -1;
            int sudjectId = -1;
            int countBefore = attObj.GetAttachment().Count();
            //Act
            attObj = new AttachmentController();
            void actAction() => attObj.AddNewSubject(teasherId, sudjectId);
            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }

        [TestMethod]
        public void DropAttachment_AddingCorrectData_trueReturned()
        {
            //Arrange
            db = new Core();
            attObj = new AttachmentController();
            int teasherId = 2;
            int sudjectId = 2;
            bool result = attObj.AddNewSubject(teasherId, sudjectId);
            int countBefore = attObj.GetAttachment().Count();
            //Act          
            attObj = new AttachmentController();
            Attachment addedCharity = db.context.Attachment.Where(x => x.id_teacher == teasherId && x.id_sudject == sudjectId).FirstOrDefault();
            attObj.DropAttachment(addedCharity);
            db.context.SaveChanges();
            int countAfter = attObj.GetAttachment().Count();
            if (countAfter != countBefore-1)
            {
                result = false;

            }         
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DropAttachment_AddingExceptionData_ExceptionReturned()
        {
            //Arrange
            db = new Core();
            attObj = new AttachmentController();
            int teasherId = 200;
            int sudjectId = 200;
            int countBefore = attObj.GetAttachment().Count();
            //Act          
            attObj = new AttachmentController();
            Attachment addedCharity = db.context.Attachment.Where(x => x.id_teacher == teasherId && x.id_sudject == sudjectId).FirstOrDefault();                
            void actAction() => attObj.DropAttachment(addedCharity);

            //Assert
            Assert.ThrowsException<Exception>(actAction);
        }
        [TestMethod]
        public void CheckSubjectDuplication_AddingCorrectData_trueReturned()
        {
            //Arrange
            attObj = new AttachmentController();
            int sudjId = 10;
            int teasherId = 10;
            //Act
            bool result = attObj.CheckSubjectDuplication(sudjId, teasherId);       
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckSubjectDuplication_AddingCorrectData_falseReturned()
        {
            //Arrange
            attObj = new AttachmentController();
            int sudjId = 2;
            int teasherId = 2;
            //Act
            bool result = attObj.CheckSubjectDuplication(sudjId, teasherId);
            //Assert
            Assert.IsFalse(result);
        }
    }
}
