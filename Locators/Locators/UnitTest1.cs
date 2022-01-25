using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Locators
{
    public class Tests
    {
        static IWebDriver driver;
        string url = "https://allo.ua/";
        WebDriverWait wait;
        Actions action = new Actions(driver);

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl(url);
        }

        [Test, Order(1)]
        public void CheckingIfCangingOfLocationIsCorrect()
        {
            WaitVisibilityOfElement(20, By.CssSelector("button[data-geo-label]"));
            var locationButton = driver.FindElement(By.XPath("//span[@class='mh-loc__label']"));
            locationButton.Click();
            wait.Until(drvr => drvr.FindElement(By.CssSelector("section[data-geo-tooltip]")));
            driver.FindElement(By.XPath("//a[@data-geo-select-city='Õàðê³â']")).Click();
            WaitVisibilityOfElement(20, By.CssSelector("button[data-geo-label]"));
            StringAssert.Contains("Õàðê³â", driver.FindElement(By.XPath("//span[@class='mh-loc__label']")).Text);

            driver.FindElement(By.XPath("//div[@class='mh-lang']")).Click();
            WaitVisibilityOfElement(20, By.XPath("//div[@class='mh-lang']"));
        }

        [Test, Order(2)]
        public void CheckingLanguageChange()
        {
            wait.Until(drvr => drvr.FindElement(By.XPath("//div[@class='mh-lang']")));
            var langRUButton = driver.FindElement(By.XPath("//span[contains(text(), 'RU')]"));
            string langRUClassValue = langRUButton.GetAttribute("class");
            if (!langRUClassValue.Contains("active"))
            {
                langRUButton.Click();
            }
            wait.Until(ExpectedConditions.StalenessOf(langRUButton));
            StringAssert.Contains("active", driver.FindElement(By.XPath("//span[contains(text(), 'RU')]")).GetAttribute("class"));
        }

        [Test, Order(3)]
        public void CheckingFirstItemofSearchIsrelevant()
        {
            WaitVisibilityOfElement(20, By.Id("search-form__input"));
            var searchString = driver.FindElement(By.Id("search-form__input"));
            searchString.SendKeys("lg");
            searchString.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-search-suggest-products]")));
            driver.FindElement(By.XPath("//li[@class='search-products__items'][1]")).Click();
            WaitPageLoad();
            StringAssert.Contains("lg", driver.Url);

        }

        [Test, Order(4)]
        public void CheckingSearchResultsCorrespondToSearchWord()
        {
            WaitVisibilityOfElement(20, By.Id("search-form__input"));
            var searchString = driver.FindElement(By.Id("search-form__input"));
            searchString.SendKeys("lg");
            var searchButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchButton.Click();
            Thread.Sleep(10000);
            var searchResults = driver.FindElements(By.XPath("//a[@class = 'product-card__title']"));
            foreach (var item in searchResults)
            {
                StringAssert.Contains("lg", item.Text.ToLower());
            }
        }

        [Test, Order(5)]
        public void CheckingFilteringCorresponsDataToFilteredResults()
        {
            WaitPageLoad();
            action.MoveToElement(driver.FindElement(By.XPath("//a[@data-category-id=1516]"))).Perform();
            WaitVisibilityOfElement(20, By.XPath("//a[@title='Apple']"));
            driver.FindElement(By.XPath("//a[@title='Apple']")).Click();
            WaitPageLoad();
            driver.FindElement(By.Id("pricerange-to")).Clear();
            driver.FindElement(By.Id("pricerange-to")).SendKeys("18000");
            driver.FindElement(By.Id("filter_id-markdown")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        public void WaitVisibilityOfElement(int waitingTime, By selector)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }

        public void WaitPageLoad()
        {
            var timeout = 10000;
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(drvr => ((IJavaScriptExecutor)drvr).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}