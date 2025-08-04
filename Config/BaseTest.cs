using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace Saucedemo_Example.Config
{
    public class BaseTest
    {
        protected  IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
        

    }
}