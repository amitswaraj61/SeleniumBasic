using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.Upload_and_Download
{
    class DownloadTest
    {


        [Test]
        public void DownloadFile()
        {
            ChromeOptions options = new ChromeOptions(); //this class is used to download and store the file in particular location
            //direction where your file downloaded
            options.AddUserProfilePreference("download.default_directory", @"C:\Users\Kis\source\repos\SeleniumBasicProgram\SeleniumBasicProgram\downloadFile1");

            IWebDriver driver = new ChromeDriver(options);
            driver.Url = "http://www.uitestpractice.com/students/widgets";

            driver.Manage().Window.Maximize(); //Maximize the windows

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait

            IWebElement download = driver.FindElement(By.XPath("//a[contains(text(),'Download a image')]"));
            Thread.Sleep(2000);
            download.Click();
            Thread.Sleep(3000); // wait is compulsory
            driver.Quit();
        }
        [Test]
        public void UploadFile()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.uitestpractice.com/students/widgets";
            Thread.Sleep(2000);


            driver.Manage().Window.Maximize(); //Maximize the windows

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait

            IWebElement chooseFile = driver.FindElement(By.Id("image_file"));
            Thread.Sleep(2000);
            chooseFile.SendKeys(@"C:\Users\Kis\Desktop\qa.png");
            Thread.Sleep(2000);

            IWebElement uploadButton = driver.FindElement(By.XPath("//body/div/div/div/div/form/div/input[1]"));
            Thread.Sleep(2000);
            uploadButton.Click();
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
