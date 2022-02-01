using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Locators.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public Actions action;
       
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            action = new Actions(driver);
            PageFactory.InitElements(driver, this);
        }

        public void WaitPageLoad()
        {
            var timeout = 10000;
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(drvr => ((IJavaScriptExecutor)drvr).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitVisibilityOfElement(int waitingTime, By selector)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }
    }
}
