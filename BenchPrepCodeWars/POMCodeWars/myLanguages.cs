using OpenQA.Selenium;
using System.Threading;

namespace BenchPrepCodeWars.POMCodeWars
{
    public class myLanguages : BasePage
    {
        private string myLanguages_url = "https://www.codewars.com/kata/latest/my-languages";
        private IWebElement search_input { get { return driver.FindElement(By.Id("search-input")); } }
        private IWebElement search_button { get { return driver.FindElement(By.Id("search")); } }


        public myLanguages(IWebDriver d) : base(d)
        {
        }
        public string GetPageTitle()
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString().Equals("complete"));
            return driver.Title;
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(myLanguages_url);
            fluentWait.Until(x => x.FindElement(By.Id("search-input")));
        }

        public void search (string input)
        {

            search_input.SendKeys(input);
            search_button.Click();
            Thread.Sleep(1000); // This needs to be cleaned up eventually as it can lead to unreliable results. 
            fluentWait.Until(x => x.FindElement(By.ClassName("inner-small-hex")));
        }

        public POMCodeWars.Kata selectResult(string input)
        {
            IWebElement webElement = driver.FindElement(By.LinkText(input));
            webElement.Click();
            fluentWait.Until(x => x.FindElement(By.Id("play_next_btn")));
            return new Kata(driver);
        }
    }
}
