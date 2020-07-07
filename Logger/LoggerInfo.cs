using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.Logger
{
    class LoggerInfo
    {
        IWebDriver driver = new ChromeDriver();
        //Declare Logger here
        private static readonly log4net.ILog log =
       log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



       [Test]
        public void HandleFrame()
        {

            log.Info("Starting the test and understand logging framework");
            driver.Manage().Window.Maximize();
            driver.Url = "http://demo.automationtesting.in/Frames.html";
            //Frame Xpath 
            IWebElement frame = driver.FindElement(By.CssSelector("#singleframe"));
            //here forcly enter in here
            driver.SwitchTo().Frame(frame);
            Thread.Sleep(2000);
            //test field under frame path
            IWebElement testField = driver.FindElement(By.XPath("//html//body//section//div//div//div//input"));
            testField.SendKeys("Hello I am Amit");
            Thread.Sleep(2000);

            //perform other task then out out from frame
            driver.SwitchTo().DefaultContent();// default content -->main window
            Thread.Sleep(2000);

            //Xpath of Iframe button
            IWebElement IframeButton = driver.FindElement(By.XPath("//a[contains(text(),'Iframe with in an Iframe')]"));
            //click on Iframe
            IframeButton.Click();
            Thread.Sleep(2000);


            //Second method to enter in frame i.e index wise n privious is elements wise 
            driver.SwitchTo().Frame(1);
            //frame under frame enter
            driver.SwitchTo().Frame(0);

            //enter xpath of test field under frame
            IWebElement Iframe1 = driver.FindElement(By.XPath("//html//body//section//div//div//div//input"));
            Iframe1.SendKeys("Hello Swaraj");
            Thread.Sleep(2000);
            //here quit the driver
            driver.Quit();
        }
    }
}
