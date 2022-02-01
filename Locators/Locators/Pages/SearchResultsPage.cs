using OpenQA.Selenium;
using System.Collections.Generic;

namespace Locators.Pages
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            this.driver = base.driver;
        }

        public IReadOnlyList<IWebElement> ProductsList => driver.FindElements(By.XPath("//a[@class = 'product-card__title']"));
    }
}
