using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.EventFiring
{
  public class EventFiringWebDriverTest
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void DemoEventFiringWebDriver()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com";

            EventFiringWebDriver eventFiringWebDriver = new EventFiringWebDriver(driver);
            //Click Events
            eventFiringWebDriver.ElementClicking += EventFiringWebDriver_ElementClicking;
            eventFiringWebDriver.ElementClicked += EventFiringWebDriver_ElementClicked;

            //Element value changing
            eventFiringWebDriver.ElementValueChanging += EventFiringWebDriver_ElementValueChanging;
            eventFiringWebDriver.ElementValueChanged += EventFiringWebDriver_ElementValueChanged;

            //Navigating events
            eventFiringWebDriver.Navigating += EventFiringWebDriver_Navigating;
            eventFiringWebDriver.Navigated += EventFiringWebDriver_Navigated;

            //Navigating forward
            eventFiringWebDriver.NavigatingForward += EventFiringWebDriver_NavigatingForward;
            eventFiringWebDriver.NavigatedForward += EventFiringWebDriver_NavigatedForward;

            //Navigating Backward
            eventFiringWebDriver.NavigatingBack += EventFiringWebDriver_NavigatingBack;
            eventFiringWebDriver.NavigatedBack += EventFiringWebDriver_NavigatedBack;

            //Script Execute Events
            eventFiringWebDriver.ScriptExecuting += EventFiringWebDriver_ScriptExecuting;
            eventFiringWebDriver.ScriptExecuted += EventFiringWebDriver_ScriptExecuted;

            //Exception Thrown Event
            eventFiringWebDriver.ExceptionThrown += EventFiringWebDriver_ExceptionThrown;


            driver = eventFiringWebDriver; // make event firing web driver

            driver.FindElement(By.LinkText("Form")).Click(); //for clicking event
            Thread.Sleep(5000);

            driver.FindElement(By.Id("firstname")).SendKeys("Amit swaraj"); // for value changing event
            Thread.Sleep(5000);

            //Navigating events
            driver.Navigate().GoToUrl("http://uitestpractice.com");
            Thread.Sleep(3000);
            driver.Navigate().Back();
            Thread.Sleep(3000);
            driver.Navigate().Forward();
            Thread.Sleep(5000);

            //script execution events
            ((IJavaScriptExecutor)driver).ExecuteScript("alert('Javascript executing')");
            Thread.Sleep(5000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);

            //Exception thrown events
            driver.FindElement(By.Id("NonExistantId")).Click();
            Thread.Sleep(5000);

            driver.Quit();

        }

        private void EventFiringWebDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine("Exception thrown");
            e.Driver.Quit();
        }

        private void EventFiringWebDriver_ScriptExecuted(object sender, WebDriverScriptEventArgs e)
        {
            Console.WriteLine("Javascript executed");
        }

        private void EventFiringWebDriver_ScriptExecuting(object sender, WebDriverScriptEventArgs e)
        {

            Console.WriteLine("Javascript executing");
        }

        private void EventFiringWebDriver_NavigatedBack(object sender, WebDriverNavigationEventArgs e)
        {
             Console.WriteLine("Navigated Backward");
        }

        private void EventFiringWebDriver_NavigatingBack(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigating Backward");
        }

        private void EventFiringWebDriver_NavigatedForward(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated Forward");
        }

        private void EventFiringWebDriver_NavigatingForward(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigating Forward");
        }

        private void EventFiringWebDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated");
        }

        private void EventFiringWebDriver_Navigating(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigating");
        }

        private void EventFiringWebDriver_ElementValueChanged(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("Element value changed");
        }

        private void EventFiringWebDriver_ElementValueChanging(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("Element value changing");
        }

        private void EventFiringWebDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element clicked");
        }

        private void EventFiringWebDriver_ElementClicking(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element clicking");
        }
    }
    }

