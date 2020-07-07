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

namespace SeleniumBasicProgram.Email
{
    class SendEmailMain
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void SendMail()
        {
            try { 
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "https://jqueryui.com/resizable/";

            driver.SwitchTo().Frame(0); //move inside the frame ..to perform task ..here only 1 frame

            IWebElement resize = driver.FindElement(By.XPath("//body/div[3]"));
            Thread.Sleep(2000);

            //Actions class
            Actions action = new Actions(driver);

            action.MoveToElement(resize).DragAndDropToOffset(resize, 100, 100);
            //in resizeable first move mouse to element then resize it here we give x and y both to resize
            Thread.Sleep(2000);

        }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                SendMailTest.SendEmail(e.Message.Trim(), e.StackTrace);
            }
            finally
            {
                driver.Quit();

            }

        }
    }
}
