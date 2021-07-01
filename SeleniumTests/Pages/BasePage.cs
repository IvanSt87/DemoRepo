namespace SeleniumTests.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System;

    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Actions = new Actions(driver);
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        public IWebDriver Driver { get; private set; }

        public WebDriverWait Wait { get; set; }

        public Actions Actions { get; private set; }

        public void ScrollTo(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ScrollUp(int offset)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.scrollBy(0, -{offset});");
        }

    }
}
