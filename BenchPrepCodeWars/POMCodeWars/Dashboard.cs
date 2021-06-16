using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchPrepCodeWars.POMCodeWars
{
    public class Dashboard : BasePage
    {
        public Dashboard(IWebDriver d) : base(d)
        {
        }
        public string GetPageTitle()
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString().Equals("complete"));
            return driver.Title;
        }
        
    }
}
