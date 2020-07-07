using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.Alert
{
    class AlertTest
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void SimpleAlertTest()
        {
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //Url of website

            driver.Manage().Window.Maximize(); //Maximize the windows

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait

            IWebElement simple = driver.FindElement(By.Id("alert")); // alert button id
            simple.Click(); //click on simple button
            Thread.Sleep(2000);

            String actual = driver.SwitchTo().Alert().Text; //get the test inside the alert
            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept(); // to accept and close use this in simple alert
            Thread.Sleep(2000);

            String val = "Hello Alert";

            Assert.AreEqual(val, actual);
            driver.Quit();
        }

        [Test]
        public void PromtAlertTest()
        {
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //Url of website

            driver.Manage().Window.Maximize(); //Maximize the windows

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait

            IWebElement simple = driver.FindElement(By.Id("prompt")); // prompt alert button id
            simple.Click(); //click on simple button
            Thread.Sleep(3000);

            driver.SwitchTo().Alert().SendKeys("amit swaraj"); //give value to prmot alert
            Thread.Sleep(3000);
            driver.SwitchTo().Alert().Accept(); //accept the alert and come out from alert
            Thread.Sleep(3000);

            // driver.SwitchTo().Alert().Dismiss(); user for cancil and come out from alert
            driver.Quit();
        }
        [Test]
        public void ConfirmAlertTest()
        {
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //Url of website

            driver.Manage().Window.Maximize(); //Maximize the windows

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait

            IWebElement conform = driver.FindElement(By.Id("confirm")); // prompt alert button id
            conform.Click(); //click on simple button
            Thread.Sleep(3000);


            String actual = driver.SwitchTo().Alert().Text; //get the test inside the alert
            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept(); // to accept and close use this in conform alert
            Thread.Sleep(2000);

            //  driver.SwitchTo().Alert().Dismiss(); to cancel used this in conform alert 
            String val = "Hello Alert";
            Assert.AreEqual(val, actual);
            driver.Quit();
        }
    }
}
