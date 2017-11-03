using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium.EazyWay;
using Selenium.EazyWay.Test.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Selenium.EaxyWay.Test
{
    public class DriverTest

    {

        [Fact]
        public void ddd()
        {

            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("http://www.TvQuran.com");

            Login LoginView = new Login();
            

            driver.LoadPage<Page>(LoginView);
            driver.Quit();
        
          
        }
    }
    

}
