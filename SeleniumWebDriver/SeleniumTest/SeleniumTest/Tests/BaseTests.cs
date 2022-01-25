using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Selenium.dev;

namespace SeleniumTest.Tests
{
    public class BaseTests
    {
        static IWebDriver driver;
        string url = "https://www.selenium.dev/";
  
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
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
        public DocumentationPage GetDocumentationPage()
        {
            return new DocumentationPage(GetDriver());
        }
    }
}