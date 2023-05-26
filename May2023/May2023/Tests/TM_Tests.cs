using May2023.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using May2023.Utilities;
using NUnit.Framework;

namespace May2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        Homepage homePageObj = new Homepage();
        TMPage tmPageObj = new TMPage();

        [Test, Order (1)]
        public void CreateTime_Test()
        {
            // TM page object initialization and definition
            homePageObj.GoToTMPage(driver);
            tmPageObj.CreateTime(driver);
        }

        [Test, Order (2)]
        public void EditTime_Test()
        {
            // TM page object initialization and definition
            homePageObj.GoToTMPage(driver);
            // Edit Time record
            tmPageObj.EditTM(driver);
        }

        [Test, Order (3)]
        public void DeleteTime_Test()
        {
            // TM page object initialization and definition
            homePageObj.GoToTMPage(driver);
            // Delete Time record
            tmPageObj.DeleteTM(driver);
        }
    }
}
