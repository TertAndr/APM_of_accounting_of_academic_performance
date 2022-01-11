using APM_of_accounting_of_academic_performance.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace APM_UnitTest
{
    [TestClass]
    public class Type_of_clocksUnitTest
    {
        Core db = new Core();
        Type_of_clocksController typObj = new Type_of_clocksController();
        [TestMethod]
        public void GetType_of_clocks_in_the_specialtys_GetDbData_trueReturned()
        {
            //Arrange
            typObj = new Type_of_clocksController();
            //Act
            bool result = typObj.GetType_of_clocks().Count() > 0;
            //Assert
            Assert.IsTrue(result);
        }
    }
}
