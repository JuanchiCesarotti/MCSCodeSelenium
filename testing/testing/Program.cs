using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            //      options.AddArgument("--no-startup-window");

            IWebDriver driver = new ChromeDriver(driverService, options);
            driver.Manage().Window.Position = new System.Drawing.Point(-2000, 0);


            driver.Navigate().GoToUrl("https://www.mcs.com.pr/");

            IWebElement img = driver.FindElement(By.Id("imgPrefetch"));

            driver.Quit();


        }
    }
}
