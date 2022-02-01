using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Locators.Pages
{
    public class HomePage : BasePage
    {
        string searchInput = "lg";
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = base.driver;
        }

        [FindsBy(How = How.XPath, Using = "//span[@class='mh-loc__label']")] public IWebElement LocationButton { get; set; }

        [FindsBy (How = How.XPath, Using = "//a[@data-geo-select-city='Харків']")] public IWebElement CityButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'RU')]")] public IWebElement LanguageRuButton { get; set; }

        [FindsBy(How = How.Id, Using = "search-form__input]")] public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='search-products__items'][1]")] public IWebElement FirstProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")] public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Смартфони та телефони']")] public IWebElement SectionLine { get; set; }

        [FindsBy (How = How.XPath, Using = "//a[@title='Apple']")] public IWebElement AppleSectionButton { get; set; } 

        public void ClickLocationButton()
        {
            LocationButton.Click();
        }
        public void ClickCityButton()
        {
            CityButton.Click();
        }
        public void ClickLanguageRuButton()
        {
            LanguageRuButton.Click();
        }
        public void InputSearchValue()
        {
            SearchInput.SendKeys(searchInput);
            SearchInput.Click();
        }
        public void GoToFirstProductPage()
        {
            FirstProduct.Click();
        }
        public void ClickSearchButton()
        {
            SearchButton.Click();
        }
        public void MoveToSectionLine()
        {
            action.MoveToElement(SectionLine).Perform();
        }

        public void GoToAppleSection()
        {
            AppleSectionButton.Click();
        }
    }
}
