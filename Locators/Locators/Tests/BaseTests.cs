using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Locators.Pages;

namespace Locators
{
    public class BaseTests
    {
        static IWebDriver driver;
        string url = "https://allo.ua/";
        public Actions action;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            action = new Actions(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
        public HomePage GetHomePage()
        {
            return new HomePage(GetDriver());
        }
        public ProductPage GetProductPage()
        {
            return new ProductPage(GetDriver());
        }
        public SearchResultsPage GetSearchResultstPage()
        {
            return new SearchResultsPage(GetDriver());
        }
        public SectionPage GetSectionPage()
        {
            return new SectionPage(GetDriver());
        }
    }
}
