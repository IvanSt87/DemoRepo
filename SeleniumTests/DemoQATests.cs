namespace SeleniumTests
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SeleniumTests.Pages;
    using SeleniumTests.Pages.DemoQA;
    using System.IO;

    public class DemoQATests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private AutoCompletePage _autoComplete;
        private DatePickerPage _datePicker;
        private NaviogationBarPage _navigationBar;
        private BasePage _basePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _homePage = new HomePage(_driver);
            _autoComplete = new AutoCompletePage(_driver);
            _datePicker = new DatePickerPage(_driver);
            _navigationBar = new NaviogationBarPage(_driver);
            _basePage = new BasePage(_driver);
            _driver.Url = "https://demoqa.com/";

            _homePage.ScrollTo(_homePage.Widget);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile($"{Directory.GetCurrentDirectory()}/{TestContext.CurrentContext.Test.Name}.png", ScreenshotImageFormat.Png);
            }

            _driver.Quit();
        }

        [Test]
        public void AutoCompleteMultiColor()
        {
            _homePage.Widget.Click();
            _navigationBar.ScrollTo(_navigationBar.AutoComplete);
            _navigationBar.AutoComplete.Click();
            _autoComplete.autoCompleteMultipleInput.SendKeys("Red");
            _basePage.Actions.SendKeys(Keys.Enter).Perform();

            string actualText = _autoComplete.MultiColorNamesField.Text;
            Assert.AreEqual(actualText, "Red");
        }

        [Test]
        public void AutoCompleteSingleColor()
        {
            _homePage.Widget.Click();
            _navigationBar.ScrollTo(_navigationBar.AutoComplete);
            _navigationBar.AutoComplete.Click();
            _autoComplete.SingleColorNameField.SendKeys("Gr");

            var text = _autoComplete.AutoCompleteBox.Text;

            Assert.IsTrue(text.Contains("Green"));
        }

        [Test]
        public void HoverOverNotSelectedDay()
        {
            _homePage.Widget.Click();
            _navigationBar.ScrollTo(_navigationBar.DatePicker);
            _navigationBar.DatePicker.Click();
            _datePicker.SelectDateField.Click();
            _basePage.Actions.MoveToElement(_datePicker.NotSelectedDay).Perform();
            var background = _datePicker.NotSelectedDay.GetCssValue("background").Remove(18, 55);
            var color = _datePicker.NotSelectedDay.GetCssValue("color");

            Assert.AreEqual(color, "rgba(0, 0, 0, 1)");
            Assert.AreEqual(background, "rgb(240, 240, 240)");
        }
    }
}
