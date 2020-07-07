using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.Tooltip
{
    class ToolTipTest
    {

        [Test]
        public void ToolTipsTest()
        {
            //load the chrome driver
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://demo.guru99.com/test/social-icon.html";
            IWebElement element = driver.FindElement(By.XPath("//body//a[5]"));
            String actualResult = element.GetAttribute("title");
            String result = "Facebook";
            Assert.AreEqual(result, actualResult);
            driver.Quit();
        }
    }
}
