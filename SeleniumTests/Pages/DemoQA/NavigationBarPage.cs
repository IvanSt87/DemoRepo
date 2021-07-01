namespace SeleniumTests.Pages.DemoQA
{
    using OpenQA.Selenium;

    public class NaviogationBarPage : BasePage
    {
        public NaviogationBarPage(IWebDriver driver): base(driver)
        {
        }

        public IWebElement AutoComplete => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Auto Complete']"));

        public IWebElement DatePicker => Driver.FindElement(By.XPath($".//*[normalize-space(text())='Date Picker']"));

    }
}
