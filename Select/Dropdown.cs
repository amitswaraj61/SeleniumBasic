using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.Select
{
    class Dropdown
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void DropDownMultipleSelectDropDownTest()
        {
            try
            {
                driver.Url = "http://www.uitestpractice.com/Students/Select"; //Url of website

                driver.Manage().Window.Maximize(); //Maximize the windows

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // implicit wait

                IWebElement dropdown = driver.FindElement(By.Id("countriesSingle"));

                SelectElement selectElement = new SelectElement(dropdown); //Create select element

                //options properties gets the list of optins belonging to the select tag
                IList<IWebElement> elements = selectElement.Options; //options for multiple drowndown list and store in list

                Console.WriteLine(elements.Count); // print the number presents in dropdown list
                Thread.Sleep(3000);


                foreach (var item in elements)
                {
                    Console.WriteLine(item.Text); //print all the test in dropdown list

                }
                Thread.Sleep(3000);

                IWebElement multiDropdown = driver.FindElement(By.Id("countriesMultiple"));
                Thread.Sleep(3000);

                SelectElement selectmultiple = new SelectElement(multiDropdown); //create multiple select downlaod
                Thread.Sleep(3000);

                bool isMultiple = selectmultiple.IsMultiple; //checking selected dropdown is multiple dropdown or simple dropdown
                Thread.Sleep(2000);
                Console.WriteLine(isMultiple); // return value in true and false
                Thread.Sleep(2000);

                //slect by test works on multiple dropdown list

                selectmultiple.SelectByText("India");
                Thread.Sleep(2000); //in multiple dorpdown list select by test "india"

                selectmultiple.DeselectByText("India");
                Thread.Sleep(2000); // here selected by test element is deselected by this properties

                selectElement.SelectByIndex(1); // here selected elements by index 
                Thread.Sleep(2000);

                selectmultiple.DeselectByIndex(1); //here deslecting by index
                Thread.Sleep(2000);

                selectmultiple.SelectByValue("china"); //value is comming from inspecting element you want to select and take value
                Thread.Sleep(2000);

                selectmultiple.DeselectByValue("china"); //here deselecting the value
                Thread.Sleep(2000);

                //select multiple value in multiple dropdown and print the value you selected
                selectmultiple.SelectByIndex(1);
                selectmultiple.SelectByIndex(2); // selecting 1 n 2 both

                IList<IWebElement> element = selectmultiple.AllSelectedOptions; // here select mulltiple value store in list
                Thread.Sleep(2000);
                Console.WriteLine(element.Count); // count the multiple selected item

                foreach (var item in element) // here printing all the selected values
                {
                    Console.WriteLine(item.Text);
                    Thread.Sleep(2000);
                }
                Thread.Sleep(2000);

                selectmultiple.DeselectAll(); // here multiple values is diselected 
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












  