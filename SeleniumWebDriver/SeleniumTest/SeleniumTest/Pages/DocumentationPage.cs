using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumTest.Selenium.dev
{
    public class DocumentationPage : BasePage
    {
        public DocumentationPage(IWebDriver driver) : base(driver)
        {
            this.driver = base.driver;
        }

        public IReadOnlyList<IWebElement> LanguagesList => driver.FindElements(By.XPath("//ul[@id='tabs-3']//a"));
        public IReadOnlyList<IWebElement> LanguageBox => driver.FindElements(By.XPath("//code[contains(@class, 'language')]"));
    }
}
