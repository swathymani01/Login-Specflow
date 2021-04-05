using GenSolveTest.Extensions;
using GenSolveTest.Model;
using OpenQA.Selenium;

namespace GenSolveTest.Pages
{
    
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl($"{BaseUrl}");
            //IsPageDisplayed();
        }

        protected By _organisation = By.XPath("//input[@placeholder='Organisation']");
        protected By _username = By.XPath("//input[@placeholder='Username']");
        protected By _password = By.XPath("//input[@formcontrolname='password']");
        protected By _loginButton = By.Id("loginButton");
        protected By _alert=By.XPath("//ngb-alert[@role='alert]");

        protected IWebElement Organisation => Driver.FindElement(_organisation);
        protected IWebElement Username => Driver.FindElement(_username);
        protected IWebElement Password => Driver.FindElement(_password);

        protected IWebElement LoginButton => Driver.FindElement(_loginButton);

        protected IWebElement Message1 => Driver.FindElement(_alert);

        public object GetMessage { get; internal set; }
        public object Message { get; internal set; }

        public string invalidCredentials = "Invalid Credentials";
        public string validCredentials = "// To do Update";

        public void Login(Login loginDetails)
        {
            Organisation.SendKeys(loginDetails.Organisation);
            Username.SendKeys(loginDetails.Username);
            Password.SendKeys(loginDetails.Password);
            LoginButton.Click();
        }

        void IsPageDisplayed()
        {
            Driver.WaitUntilElementIsDisplay(_loginButton);
        }
    }
}

