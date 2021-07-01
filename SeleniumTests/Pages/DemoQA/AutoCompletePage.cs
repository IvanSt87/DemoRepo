namespace SeleniumTests.Pages.DemoQA
{
    using OpenQA.Selenium;

    public class AutoCompletePage : NaviogationBarPage
    {
        public AutoCompletePage(IWebDriver driver): base(driver)
        {
        }

        public IWebElement autoCompleteMultipleInput => Wait.Until( d => d.FindElement(
            By.Id("autoCompleteMultipleInput")));

        public IWebElement MultiColorNamesField => Driver.FindElement(
            By.XPath("//div[@class='css-12jo7m5 auto-complete__multi-value__label']"));

        public IWebElement SingleColorNameField => Driver.FindElement(By.Id("autoCompleteSingleInput"));

        public IWebElement AutoCompleteBox => Driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]"));
    }
}
