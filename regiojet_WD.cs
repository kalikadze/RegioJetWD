using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace RegioJetWD
{
    [TestFixture]
    public class RegiojetWD
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest(string baseURL)
        {
            driver = new FirefoxDriver();
            //baseURL = "https://cestovnelistky.studentagency.sk/Booking/from/BAS/to/ZAH/tarif/ISIC/departure/20160520/retdep/20160519/return/false/ropen/false/credit/false/class/2?4#search-results";
            verificationErrors = new StringBuilder();
            driver.Navigate().GoToUrl(baseURL);
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public List<int> TheRegiojetWDTest()
        {
            try
            {
                By @by = By.XPath("//div[contains(@class,'col_space gray_gradient')]");
                var element = driver.FindElements(by);
                List<int> freeSpaces = new List<int>();
                
                for (int i = 0; i < element.Count; i++)
                {
                    int intnum = 0;
                    if (int.TryParse(element[i].Text.ToString(), out intnum))
                    {
                        freeSpaces.Add(intnum);
                    }                    
                }
                return freeSpaces;
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                return null;
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
