using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchPrepCodeWars.POMCodeWars
{
    public abstract class BasePage
    {
        private IWebDriver _driver { get; set; }
        private WebDriverWait w;
        private DefaultWait<IWebDriver> fw;

        public WebDriverWait wait { get { return w; } }
        public DefaultWait<IWebDriver> fluentWait { get { return fw; } }
        public IWebDriver driver
        {
            get { return _driver; }
        }

        public BasePage(IWebDriver d)
        {
            this._driver = d;
            w = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            fw = new DefaultWait<IWebDriver>(_driver);
            fw.Timeout = TimeSpan.FromSeconds(5);
            fw.PollingInterval = TimeSpan.FromMilliseconds(200);
            fw.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

    }
}
