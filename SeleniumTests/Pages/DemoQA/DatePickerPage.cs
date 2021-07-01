namespace SeleniumTests.Pages.DemoQA
{
    using OpenQA.Selenium;

    public class DatePickerPage : NaviogationBarPage
    {
        public DatePickerPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SelectDateField => Wait.Until(d => d.FindElement(By.Id("datePickerMonthYearInput")));

        public IWebElement NotSelectedDay => Wait.Until(d => d.FindElement(By.XPath("//*[@id='datePickerMonthYear']/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div[2]")));

    }
}
