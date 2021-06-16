using OpenQA.Selenium;

namespace BenchPrepCodeWars.POMCodeWars
{
    public class Kata: BasePage
    {
        private IWebElement train_button { get { return driver.FindElement(By.Id("play_btn")); } }
        private IWebElement replay_button { get { return driver.FindElement(By.Id("replay_btn")); } }
        public Kata(IWebDriver d) : base(d)
        {
        }
        public Train Train()
        {
            try
            {
                train_button.Click();
            }
            catch (NoSuchElementException)
            {
                replay_button.Click();
            }
            fluentWait.Until(x => x.FindElement(By.Id("editors")));
            return new Train(driver);
        }
    }
}
