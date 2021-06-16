using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchPrepCodeWars.POMCodeWars
{
    public class SignInPage : BasePage
    {
        string signin_url = "https://www.codewars.com/users/sign_in";
        private IWebElement elem_user_email { get { return driver.FindElement(By.Id("user_email")); } }
        private IWebElement elem_user_password { get { return driver.FindElement(By.Id("user_password")); } }
        public SignInPage(IWebDriver d) : base(d) 
        { 
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(signin_url);
        }

        public Dashboard LogIn(string email, string password)
        {
            GoToPage();
            elem_user_email.SendKeys(email);
            elem_user_password.SendKeys(password);
            elem_user_password.Submit();
            fluentWait.Until(x => x.FindElement(By.Id("header_profile_link")));
            return new Dashboard(driver);
        }

        public void InvalidLogIn(string email, string password)
        {
            GoToPage();
            elem_user_email.SendKeys(email);
            elem_user_password.SendKeys(password);
            elem_user_password.Submit();
            fluentWait.Until(x => x.FindElement(By.ClassName("alert-box")));
        }
    }
}
