using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollService;

namespace EmployeePayrollServiceTestProject
{

    [TestClass]
    public class UnitTest1
    {
        EmployeeRepository repository;
        EmployeeDetails details;
        [TestInitialize]
        public void SetUp()
        {
            repository = new EmployeeRepository();
            details = new EmployeeDetails();
        }

        [TestMethod]
        public void TestUpdateSalaryUsingPreparedStatement()
        {
            ///AAA Methodology
            //Arrange
            int expected = 1;
            details.EmployeeID = 6;
            details.EmployeeName = "Terissa";
            details.BasicPay = 3000000;
            //Act
            int actual = repository.UpdateSalaryusingPreparedStatement(details);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
