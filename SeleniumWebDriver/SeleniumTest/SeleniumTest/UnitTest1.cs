using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            var searchButton = driver.FindElement(By.XPath("//span[text() = 'Documentation']"));
            searchButton.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var languagesList = driver.FindElements(By.XPath("//a[contains(@id, 'tabs-3')]"));
            var expectedLanguageList = new[] { "Java", "Python", "CSharp", "Ruby", "JavaScript", "Kotlin" };
            for (int i = 0; i < expectedLanguageList.Length; i++)
            {
                StringAssert.Contains(expectedLanguageList[i], languagesList[i].Text);
            }

            var languageBox = driver.FindElements(By.XPath("//code[contains(@class, 'language')]"));

            for (int i = 0; i < languagesList.Count; i++)
            {
                languagesList[i].Click();
                languageBox[i].GetAttribute("class").Contains(languagesList[i].Text);
            }

            driver.Close();
        }
    }
}