using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumFrontEndTest
{
    public class UserStory2 : IDisposable
    {
        private string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;
        private const string URL = "http://localhost:5173/";
        public UserStory2()
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        //Type a known title (e.g. “Billie Jean”) and verify the matching record appears in the list.
        [Fact]
        public void VerifyTitleApearsInSearch()
        {
            string searchTitle = "Billie Jean";
            _driver.Navigate().GoToUrl(URL);
            IWebElement dropDownButton = _driver.FindElement(By.Id("drop-down-button"));
            dropDownButton.Click();
            IWebElement dropDownElement = _driver.FindElement(By.Id("drop-down-title"));
            dropDownElement.Click();
            IWebElement searchField = _driver.FindElement(By.Id("search-bar"));
            searchField.SendKeys(searchTitle);
            IWebElement searchButton = _driver.FindElement(By.Id("search-button"));
            searchButton.Click();
            IWebElement searchResult = _driver.FindElement(By.Id("table-data-title"));

            string actualOutput = searchResult.Text;

            Assert.Equal(searchTitle, actualOutput);
        }


        //Type a known genre and verify all of that artist’s records appear.
        [Fact]
        public void MultipleRecordsSearch()
        {
            string genreName = "pop";
            _driver.Navigate().GoToUrl(URL);
            IWebElement dropDownButton = _driver.FindElement(By.Id("drop-down-button"));
            dropDownButton.Click();
            IWebElement dropDownElement = _driver.FindElement(By.Id("drop-down-genre"));
            dropDownElement.Click();
            IWebElement searchField = _driver.FindElement(By.Id("search-bar"));
            searchField.SendKeys(genreName);
            IWebElement searchButton = _driver.FindElement(By.Id("search-button"));
            searchButton.Click();
            IWebElement searchResult = _driver.FindElement(By.Id("table-data-row"));

            bool isDisplayed = searchResult.Displayed;

            Assert.True(isDisplayed);
        }

        //Search by publication year and verify only records from that year appear.
        [Fact]

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
