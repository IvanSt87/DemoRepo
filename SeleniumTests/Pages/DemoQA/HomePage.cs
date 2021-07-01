namespace SeleniumTests.Pages.DemoQA
{
    using OpenQA.Selenium;

    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver): base(driver)
        {
        }

        public IWebElement Widget => Driver.FindElement(By.XPath("//*[normalize-space(text())='Widgets']/ancestor::div[contains(@class, 'top-card')]"));
    }
}
