using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace DotNetCoreSelenium
{
    [TestClass]
    public class SearchGoogle
    {
        [TestMethod]
        public void SearchForCheese()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {

                driver.Navigate().GoToUrl("http://www.google.com/");

                IWebElement query = driver.FindElement(By.Name("q"));

                query.SendKeys("Cheese");

                query.Submit();


                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("Cheese", StringComparison.InvariantCulture));

                Assert.IsTrue(driver.Title.Contains("Cheese"));
            }
        }
    }
}
