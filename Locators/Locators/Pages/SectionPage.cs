using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Locators.Pages
{
    public class SectionPage : BasePage
    {
        public int price = 18000;
        public SectionPage(IWebDriver driver) : base(driver)
        {
            this.driver = base.driver;
        }

        [FindsBy(How = How.XPath, Using = "//h2[@data-id='price']")] public IWebElement PriceFilter { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='pricerange-to']")] public IWebElement PriceRangeInput { get; set; }
        [FindsBy(How = How.Id, Using = "filter_id-markdown")] public IWebElement MarkDownFilter { get; set; }
        [FindsBy(How = How.XPath, Using = "(//div[@class = 'product-card'])[1]")] public IWebElement FirstProduct { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@class='filter-popup__button']")] public IWebElement ShowFilteredButton { get; set; }

        public void ClickPriceFilter()
        {
            PriceFilter.Click();
        }

        public void SetPriceRange()
        {
            PriceRangeInput.Clear();
            PriceRangeInput.SendKeys(price.ToString());
        }
        public void SelectMakrdown()
        { 
            MarkDownFilter.Click();
        }

        public void GoToFirstProductPage()
        {
            FirstProduct.Click();
        }

        public void ClickShowFilteredButton()
        {
            ShowFilteredButton.Click();
        }
    }
}
