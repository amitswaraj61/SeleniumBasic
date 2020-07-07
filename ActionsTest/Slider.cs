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

namespace SeleniumBasicProgram.ActionsTest
{
    class Slider
    {

        IWebDriver driver = new ChromeDriver();

        [Test]
        public void DragAndDropTest()
        {
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "https://jqueryui.com/slider/";

            driver.SwitchTo().Frame(0); // switch to inside the frame 

            IWebElement slider = driver.FindElement(By.XPath("//html//body//div//span"));

            Actions action = new Actions(driver);

            //for slider first move to slider button then use drag and drop offset first parameter is slider means 0,then give x or y axis for sliding
            action.MoveToElement(slider).DragAndDropToOffset(slider, 300, 0).Build().Perform();
            Thread.Sleep(2000);

            driver.Quit();
        }
    }
}
