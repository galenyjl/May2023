using May2023.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using May2023.Utilities;
using NUnit.Framework;

namespace May2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpActions()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            // Home page object initialization and definition
            Homepage homePageObj = new Homepage();
            homePageObj.GoToTMPage(driver);
        }

        [Test, Order (1)]
        public void CreateTime_Test()
        {
            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTime(driver);
        }

        [Test, Order (2)]
        public void EditTime_Test()
        {
            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            // Edit Time record
            tmPageObj.EditTM(driver);
        }

        [Test, Order (3)]
        public void DeleteTime_Test()
        {
            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            // Delete Time record
            tmPageObj.DeleteTM(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }











    }
}
