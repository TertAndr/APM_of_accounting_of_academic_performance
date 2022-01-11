using APM_of_accounting_of_academic_performance.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class RolesControllerUnitTest
    {
        Core db = new Core();
        RolesController roleObj = new RolesController();
        [TestMethod]
        public void GetType_of_clocks_in_the_specialtys_GetDbData_trueReturned()
        {
            //Arrange
            roleObj = new RolesController();
            //Act
            bool result = roleObj.GetRoles().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
    }
}
