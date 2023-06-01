using May2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;


namespace May2023.Pages
{
    public class TMPage
    {                                                                               
    
        public void CreateTime(IWebDriver driver)
        {
            IWebElement createNewButton = driver.FindElement(By.XPath("/html/body/div[4]/p/a"));
            createNewButton.Click();

            //fill out relevant fields to create a new record 
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeDropdown.Click();
            Thread.Sleep(1000);

            IWebElement timeOption = driver.FindElement(By.XPath("/html/body/div[5]/div/ul/li[2]"));
            timeOption.Click();

            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("May2023");

            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("May2023");

            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("12");

            //click save button to submit those details and create a record 
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(4000);

            //Go to last page to find our record 
            IWebElement lastButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastButton.Click();
            Thread.Sleep(1000);
        }

        public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }

        public void EditTM(IWebDriver driver, string description, string code, string price)
        {
            Thread.Sleep(3000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(4000);

            IWebElement lastElement = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lastElement.Text == "May2023")
            {
                Thread.Sleep(2000);
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(3000);
            }
            else
            {
                Assert.Fail("New record created hasn't been found.");
            }

            //edit code into code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys(code);

            //edit description into description box
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(description);

            //edit price into price per unit textbox
            IWebElement editpriceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editpriceTextbox = driver.FindElement(By.Id("Price"));

            editpriceOverlap.Click();
            editpriceTextbox.Clear();
            editpriceOverlap.Click();
            editpriceTextbox.SendKeys(price);

            //click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1000);

            //check if Time record has been edited
            IWebElement goToEditLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToEditLastPageButton.Click();
            Thread.Sleep(1500);

            ////find the last record on list page 
            //IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            //Assert.That(editedCode.Text == "June2023", "Actual Code and expected code do not match.");
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return createdDescription.Text;
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return createdCode.Text;
        }

        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement createdPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return createdPrice.Text;
        }



        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            Thread.Sleep(1000);
            IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteRecord.Click();
            

            // To Click OK in altert window
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(editedCode.Text != "June2023", "Record hasn't been deleted.");

        }
    }
}
