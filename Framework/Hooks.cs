using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace GenSolveTest.Framework
{
    [Binding]
    public sealed class Hooks
    {
        public IWebDriver Driver;

        private readonly ScenarioContext _scenarioContext;


        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string browser = Environment.GetEnvironmentVariable("browser");
            if (browser.Equals("firefox"))
            {
                Driver = new FirefoxDriver();
                Console.WriteLine("Tests execution in Firefox");
            }
            else if (browser.Equals("chrome"))
            {
                Driver = new ChromeDriver();
                Console.WriteLine("Tests execution in Chrome");
            } 

            _scenarioContext["Driver"] = Driver;
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
