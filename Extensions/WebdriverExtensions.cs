using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GenSolveTest.Extensions
{
    public static class WebdriverExtensions
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
        public static readonly TimeSpan ImplicitWait = TimeSpan.FromSeconds(3);
        public static readonly TimeSpan NoWait = TimeSpan.Zero;
        public static bool WaitUntilElementIsDisplay(this IWebDriver driver, By by, TimeSpan? timeout = null)
        {
            var wait = new WebDriverWait(driver, timeout ?? DefaultTimeout);

            try
            {
                return wait.Until(d => d.FindElement(by).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return wait.Until(d => d.FindElement(by).Displayed);
            }
        }
    }
}
