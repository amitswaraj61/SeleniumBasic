using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.Select
{
    class DateSet
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void SetDateInFacebook()
        {
            try
            {
                driver.Url = "https://www.facebook.com/"; //Url of website

                driver.Manage().Window.Maximize(); //Maximize the windows

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait

                //In face we use single dropdown

                IWebElement day = driver.FindElement(By.Id("day"));

                SelectElement selectElement = new SelectElement(day); //Create select element
                Thread.Sleep(2000);
                selectElement.SelectByIndex(15); // here selected elements by index 
                Thread.Sleep(2000);

                IWebElement month = driver.FindElement(By.Id("month"));
                Thread.Sleep(2000);
                SelectElement selectmonth = new SelectElement(month);
                selectmonth.SelectByText("Sept");
                Thread.Sleep(2000);


                IWebElement year = driver.FindElement(By.Id("year"));
                SelectElement selectElements = new SelectElement(year); //Create select element
                Thread.Sleep(2000);
                selectElements.SelectByText("1997");
                Thread.Sleep(2000);
            }
            catch (Exception exception)
            {
                Screenshot.Capture(driver, exception.Message);
                Console.WriteLine(exception.Message);
                Email.SendMailTest.SendEmail(exception.Message.Trim(), exception.StackTrace);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
                







