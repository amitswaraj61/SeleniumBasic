using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.ActionsTest
{
    class RightClick
    {

        IWebDriver driver = new ChromeDriver();

        [Test]
        public void RightClickTest()
        {
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "https://swisnl.github.io/jQuery-contextMenu/demo.html";

            //Actions class
            Actions action = new Actions(driver);

            IWebElement rightclick = driver.FindElement(By.XPath("//span[contains(text(),'right click me')]"));
            action.ContextClick(rightclick).Build().Perform(); //Context click perform right click 
            Thread.Sleep(2000);

            IWebElement copy = driver.FindElement(By.XPath("//html//body//ul//li//span[contains(text(),'Copy')]"));
            copy.Click();//click to copy
            Thread.Sleep(2000);

            Console.WriteLine(driver.SwitchTo().Alert().Text); // capture the test from alert box
            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept(); // close the box
            Thread.Sleep(2000);

            driver.Quit();
        }
    }
}
