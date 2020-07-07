using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.WindowHandling
{
    class WindowHandling
    {

        //Loading Chrome Driver
        IWebDriver driver = new ChromeDriver();
        [OneTimeSetUp]
        public void Setup()
        {
            //Url of website
            driver.Url = "http://demo.automationtesting.in/Windows.html";

            //Maximize the windows
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }

        [Test]
        public void HandleMultipleWindows()
        {
            String mainWindow = driver.Url;
            Console.WriteLine("main windows--->" + mainWindow);
            IWebElement element1 = driver.FindElement(By.XPath("//a[contains(text(),'Open New Seperate Windows')]"));
            element1.Click();
            Thread.Sleep(2000);

            IWebElement element = driver.FindElement(By.XPath("//div//div//div//div//div//div[2]//button[1]"));
            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(3000);
            // child Windows Handles and store no of child windows in list
            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window - > " + handle);
                driver.SwitchTo().Window(handle);
            }
            String ActualResult = driver.Url;
            String result = "http://www.sakinalium.in/";
            Assert.AreEqual(result, ActualResult);
        }
    }
}
