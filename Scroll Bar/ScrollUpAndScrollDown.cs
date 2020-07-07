using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.Scroll_Bar
{
    class ScrollUpAndScrollDown
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void ScrollDownAndUpTest()
        {
            driver.Url = "https://en.wikipedia.org/wiki/Main_Page"; //navigate to wikipedia page

            driver.Manage().Window.Maximize();  //maxiize the screen size

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); //impliccit wait for 20 sec

            IJavaScriptExecutor jse = driver as IJavaScriptExecutor; //creating javascripterExecuter for perform scrolldown and scrollup

            jse.ExecuteScript("window.scrollBy(0,500);"); // scrolling down in webpage
            Thread.Sleep(5000); //Weight for 5 secs
       


            jse.ExecuteScript("window.scrollBy(0,-500);");  //scrolling up in webpage
            Thread.Sleep(5000);  //Weight for 5 secs


            driver.Quit(); //quit th driver
        }
    }
}
