//
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

namespace SeleniumBasicProgram.ExceptionHandling
{
    class ExceptionTest 
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void NoSuchFrameException()
        {
            try
            {
                driver.Manage().Window.Maximize();
                driver.Url = "http://demo.automationtesting.in/Frames.html";
                //Frame Xpath 
                IWebElement frame = driver.FindElement(By.CssSelector("#singleframe"));
                //here forcly enter in here
                driver.SwitchTo().Frame(frame);
                Thread.Sleep(2000);
                //test field under frame path
                IWebElement testField = driver.FindElement(By.XPath("//html//body//section//div//div//div//input"));
                testField.SendKeys("Hello I am Amit");
                Thread.Sleep(2000);

                //perform other task then out out from frame
                driver.SwitchTo().DefaultContent();// default content -->main window
                Thread.Sleep(2000);

                //Xpath of Iframe button
                IWebElement IframeButton = driver.FindElement(By.XPath("//a[contains(text(),'Iframe with in an Iframe')]"));
                //click on Iframe
                IframeButton.Click();
                Thread.Sleep(2000);


                //Second method to enter in frame i.e index wise n privious is elements wise 
                driver.SwitchTo().Frame(1);
                //frame under frame enter
                driver.SwitchTo().Frame(1);

                //enter xpath of test field under frame
                IWebElement Iframe1 = driver.FindElement(By.XPath("//html//body//section//div//div//div//input"));
                Iframe1.SendKeys("Hello Swaraj");
                Thread.Sleep(2000);
                //here quit the driver
                driver.Quit();
            }
            catch (NoSuchFrameException e)
            {
                Screenshot.Capture(driver, "   No such frame exception");
            }
            finally
            {
                driver.Quit();
            }
        }
        [Test]
        public void NoSuchElementException()
        {
            try
            {
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
            catch(NoSuchElementException exception)
            {
                Screenshot.Capture(driver, "   No such Element exception");
                Console.WriteLine(exception.Message);
            }
            finally
            {
                driver.Quit();

            }
          
        }
        [Test]
        public void NoAlertPresentException()
        {
           
                driver.Url = "http://www.uitestpractice.com/Students/Switcht"; //Url of website

                driver.Manage().Window.Maximize(); //Maximize the windows

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait
            try
            {
                IWebElement simple = driver.FindElement(By.Id("prompt")); // prompt alert button id
                simple.Click(); //click on simple button
                Thread.Sleep(3000);

                driver.SwitchTo().Alert().SendKeys("amit swaraj"); //give value to prmot alert
                Thread.Sleep(3000);
                driver.SwitchTo().Alert().Accept(); //accept the alert and come out from alert
                Thread.Sleep(3000);
            }

            // driver.SwitchTo().Alert().Dismiss(); user for cancil and come out from alert
            catch (Exception exception)
            {
               
              Screenshot.Capture(driver, "   No such Element exception");
               Console.WriteLine(exception.Message);

            }
            finally
            {
                driver.Quit();
            }
            }

        }
    }
