using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Locators.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
            this.driver = base.driver;
        }

        [FindsBy (How = How.XPath, Using = "//h1[@itemprop ='name']")] public IWebElement ProductName { get; set; }
        [FindsBy (How = How.XPath, Using = "//span[@class='sum']")] public IWebElement ProductPrice { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@class = 'info-tag-list__item-text']")] public IWebElement MarkdownTag { get; set; }
    }
}
