using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest.Selenium.dev
{
    public class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitPageLoad()
        {
            var timeout = 10000;
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(drvr => ((IJavaScriptExecutor)drvr).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
