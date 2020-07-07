using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.ActionsTest
{
    class DrapDrop
    {
        public static ExtentReports extent = null;
        public static ExtentTest test = null;

        [OneTimeSetUp]
        public void ExtentReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Kis\source\repos\SeleniumBasicProgram\SeleniumBasicProgram\Report\Report.html");
            extent.AttachReporter(htmlReporter);
            String hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;
            extent.AddSystemInfo("operating system", hostname);
            extent.AddSystemInfo("Host name", hostname);
            extent.AddSystemInfo("Browser", "Google Chrome");
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }


        IWebDriver driver = new ChromeDriver();


        [Test]
        public void DragAndDropTest()
        {
            test = extent.CreateTest("Create new Post").Info("Test Started");
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "http://www.dhtmlgoodies.com/scripts/drag-drop-custom/demo-drag-drop-3.html";


            IWebElement source = driver.FindElement(By.XPath("//body//div[14]")); // take source postion to drop
            Thread.Sleep(2000);

            IWebElement dest = driver.FindElement(By.XPath("//div[contains(text(),'United States')]")); // drop to destination
            Thread.Sleep(2000);

            Actions action = new Actions(driver); // actions class

            //  action.ClickAndHold(source).MoveToElement(dest).Release().Build().Perform();
            //  Thread.Sleep(2000);
            //user will click and hold source position then move to dest postion and release to that postion

            //Another method to drap and drop 
            action.DragAndDrop(source, dest).Build().Perform();
            Thread.Sleep(2000);
            String path = Screenshot.Capture(driver, "DragAndDropTest");
            test.AddScreenCaptureFromPath(path);
            test.Log(Status.Info, "Chrome Browser Launched");


            driver.Quit();
        }
    }
}
