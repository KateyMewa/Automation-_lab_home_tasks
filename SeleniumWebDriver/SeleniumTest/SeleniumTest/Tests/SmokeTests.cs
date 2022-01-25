using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumTest.Tests
{
    class SmokeTests : BaseTests
    {
        private IWebDriver driver;
        readonly List<string> expectedLanguageList = new List<string> { "Java", "Python", "CSharp", "Ruby", "JavaScript", "Kotlin" };

        [Test]
        public void Test1()
        {
            GetHomePage().GoToDocumentation();
            GetHomePage().WaitPageLoad();
            for (int i = 0; i < expectedLanguageList.Count; i++)
            {
                StringAssert.Contains(expectedLanguageList[i], GetDocumentationPage().LanguagesList[i].Text);
            }

            for (int i = 0; i < GetDocumentationPage().LanguagesList.Count; i++)
            {
                GetDocumentationPage().LanguagesList[i].Click();
                StringAssert.Contains(GetDocumentationPage().LanguagesList[i].Text.ToLower(), GetDocumentationPage().LanguageBox[i].GetAttribute("class"));
            }
        }
    }
}
