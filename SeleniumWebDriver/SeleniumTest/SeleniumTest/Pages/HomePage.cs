using OpenQA.Selenium;

namespace SeleniumTest.Selenium.dev
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = base.driver;
        }
        IWebElement DocumentationButton => driver.FindElement(By.XPath("//a[@href='/documentation']"));

        public void GoToDocumentation() { DocumentationButton.Click(); }
    }
}
