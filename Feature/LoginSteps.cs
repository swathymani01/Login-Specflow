using FluentAssertions;
using GenSolveTest.Framework;
using GenSolveTest.Model;
using GenSolveTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace GenSolveTest.Feature
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver driver;
        LoginPage loginPage;
        
        private readonly ScenarioContext _scenarioContext;
        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
           driver = (IWebDriver)_scenarioContext["Driver"];
        }

        [Given(@"Open login Page")]
        public void GivenOpenLoginPage()
        {
            loginPage = new LoginPage(driver);
        }

        [When(@"Enter (.*),(.*) and (.*)")]
        public void WhenEnterDemoPracticeSpecflow_ChallengeAndTest(string org, string username, string password)
        {
             Login login = new Login(org, username, password);
             loginPage.Login(login);
        }

        [Then(@"User should login successfully")]
        public void ThenUserShouldLoginSuccessfully()
        {
             loginPage.GetMessage.Should().Be(loginPage.Message);
        }

        [Then(@"User should failed to login")]
        public void ThenUserShouldFailedToLogin()
        {
            loginPage.GetMessage.Should().Be(loginPage.invalidCredentials);
        }
    }
}
