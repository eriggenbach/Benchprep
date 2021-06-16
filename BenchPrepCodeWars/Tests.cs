using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using OpenQA.Selenium.Support.UI;

namespace BenchPrepCodeWars
{
    
    public class Tests
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private FirefoxDriver _driver;
        string email = "benchprep@sdet.com";
        string password = "c0d3Ch@llenge21";
        string homeTitle = "Home | Codewars";

        [SetUp]
        public void DriverInitialize()
        {
            
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void DriverCleanup()
        {
            _driver.Quit();
        }

        [Test]
        public void Login_ShouldSucceed_WhenValidCredentials()
        {
            POMCodeWars.SignInPage signInPage = new POMCodeWars.SignInPage(_driver);
            POMCodeWars.Dashboard dashboard =  signInPage.LogIn(email, password);

            Assert.That(dashboard.GetPageTitle, Is.EqualTo(homeTitle));

        }

        [Test]
        public void Login_ShouldFail_WhenInvalidCredentials()
        {
            POMCodeWars.SignInPage signInPage = new POMCodeWars.SignInPage(_driver);
            signInPage.InvalidLogIn(email, "badpassowrd");
            IWebElement alertBox =  _driver.FindElementByClassName("alert-box");
            Assert.That(alertBox, !Is.Null);
        }

        [Test]
        public void Search_ShouldReturnResult_WhenValidInput()
        {
            SignIn();
            POMCodeWars.myLanguages searchPage = new POMCodeWars.myLanguages(_driver);
            searchPage.GoToPage();
            searchPage.search("Conway's Game of Life - Unlimited Edition");
            IWebElement result = _driver.FindElement(By.LinkText("Conway's Game of Life - Unlimited Edition"));
            Assert.That(result.Text, Is.EqualTo("Conway's Game of Life - Unlimited Edition"));

        }

        [Test]
        public void ClickTrain_ShouldStartCodeChallenge()
        {
            SignIn();
            POMCodeWars.myLanguages resultsPage = search("Conway's Game of Life - Unlimited Edition");
            POMCodeWars.Kata kata = resultsPage.selectResult("Conway's Game of Life - Unlimited Edition");
            kata.Train();
            IWebElement editors = _driver.FindElementById("editors_area");
            Assert.That(editors.Displayed, Is.True);

        }

        #region helpers
        public POMCodeWars.myLanguages search(string input)
        {
            POMCodeWars.myLanguages searchPage = new POMCodeWars.myLanguages(_driver);
            searchPage.GoToPage();
            searchPage.search(input);
            return searchPage;
        }

        public POMCodeWars.Dashboard SignIn() {
            POMCodeWars.SignInPage signInPage = new POMCodeWars.SignInPage(_driver);
            return signInPage.LogIn(email, password);
        }
        #endregion
    }
}
