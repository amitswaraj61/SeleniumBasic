using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.DatePicker
{
    class DatePicker
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void DataPickerTest()
        {
            driver.Url = "http://demo.automationtesting.in/Datepicker.html"; //navigate to wikipedia page

            driver.Manage().Window.Maximize();  //maxiize the screen size

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); //impliccit wait for 20 sec

            IJavaScriptExecutor jse = driver as IJavaScriptExecutor; //creating javascripterExecuter for data picker
            Thread.Sleep(3000);

            jse.ExecuteScript("document.getElementById('datepicker1').value= '09/12/2019'"); //this javacsriptexecuter used to pick the date directly
            Thread.Sleep(3000);

            driver.Quit();
        }

    }
}
