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
    class KeysDownAndUp
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void KeysDownAndUpTest()
        {

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            //Action Class
            Actions action = new Actions(driver);

            action.KeyDown(driver.FindElement(By.Name("one")), Keys.Control) //keys down in web element one and key press control
            .KeyDown(driver.FindElement(By.Name("six")), Keys.Control) //keys down in web element six and key press control
           .KeyUp(driver.FindElement(By.Name("eleven")), Keys.Control)// keys down in web element Eleven and key press control
            .Build()
            .Perform();

            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void ActionSendKeyTest()
        {

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            //Action Class
            Actions action = new Actions(driver);

            Thread.Sleep(2000);
            action.SendKeys(driver.FindElement(By.Name("click")), Keys.Enter).Build().Perform();
            //here user will send key values like enter to web elements on click botton

            driver.Quit();

        }

    }
}
