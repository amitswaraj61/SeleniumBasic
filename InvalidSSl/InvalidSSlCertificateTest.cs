using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.InvalidSSl
{
   public class InvalidSSlCertificateTest
    {
        [Test]
        public void HandleInvalidSSlCertificate()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://expired.badssl.com/";
            IWebElement element = driver.FindElement(By.Id("content"));
            Console.WriteLine(element.Text);
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
