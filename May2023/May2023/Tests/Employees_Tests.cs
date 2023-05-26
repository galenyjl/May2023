using May2023.Pages;
using May2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employees_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpActions()
        {
            driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            Homepage homePageObj = new Homepage();
            homePageObj.GoToEmployeesPage(driver);

        }

        [Test]
        public void CreateEmployee_Test()
        {
            EmployeesPage employeePageObj = new EmployeesPage();
            employeePageObj.CreateEmployee(driver);
        }

        [Test]
        public void EditEmployee_Test()
        {
            EmployeesPage employeePageObj = new EmployeesPage();
            employeePageObj.EditEmployee(driver);
        }

        [Test]
        public void DeleteEmployee_Test()
        {
            EmployeesPage employeePageObj = new EmployeesPage();
            employeePageObj.DeleteEmployee(driver);
        }

        [TearDown] 
        public void TearDownActions() 
        {
            driver.Quit();
        }


    }
}
