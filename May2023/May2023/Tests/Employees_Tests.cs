using May2023.Pages;
using May2023.Utilities;
using NUnit.Framework;

namespace May2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employees_Tests : CommonDriver
    {
        Homepage homePageObj = new Homepage();
        EmployeesPage employeePageObj = new EmployeesPage();

        [Test]
        public void CreateEmployee_Test()
        {
            homePageObj.GoToEmployeesPage(driver);
            employeePageObj.CreateEmployee(driver);
        }

        [Test]
        public void EditEmployee_Test()
        {
            homePageObj.GoToEmployeesPage(driver);
            employeePageObj.EditEmployee(driver);
        }

        [Test]
        public void DeleteEmployee_Test()
        {
            homePageObj.GoToEmployeesPage(driver);
            employeePageObj.DeleteEmployee(driver);
        }
    }
}
