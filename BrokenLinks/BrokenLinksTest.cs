using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Policy;

namespace SeleniumBasicProgram.BrokenLinks
{
    class BrokenLinksTest
    {
        //Loading the chrome driver
        IWebDriver driver = new ChromeDriver();


        [Test]
        public void BrokenLinksTest1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // implicit weight for 20 secs

            driver.Navigate().GoToUrl("http://newtours.demoaut.com/"); //naviagte to this url and open web page

            String loginpage = "http://newtours.demoaut.com/"; //store the url in string loginpage

            HttpWebRequest hwr = null; //initialize the httpwebrequest to be null

            String url = null; // initialize string url to be null
          
            IList<IWebElement> tags = driver.FindElements(By.TagName("a")); //create a list to store all the anchor tag reference element

            Console.WriteLine(tags.Count()); // here print the total number of link present

            for (int i = 0; i < tags.Count; i++) // for loop for iteration purpose 
            {
                url = tags.ElementAt(i).GetAttribute("href"); // get all the href present and store in url

                if (url == null) // check conditon if the url is null print messgae
                {
                    Console.WriteLine(url + "   url is not configured"); //print url null message
                    continue;
                }

                hwr = (HttpWebRequest)WebRequest.Create(url); //create httprequest for url

                try
                {
                    var response = (HttpWebResponse)hwr.GetResponse(); // this line used to get the response

                    int responsecode = (int)response.StatusCode; // this line is used to get the status code

                    if (responsecode >= 400)  //checking condition if responce code less then 400 then save link else broken link
                    {
                        Console.WriteLine(url + "  Its a broken link  ");
                    }
                    else
                    {
                        Console.WriteLine(url + "  Its a safe link");
                    }
                }
                catch (WebException e) //exception occured
                {
                    var errorRosponse = (HttpWebResponse)e.Response; // get exception responce
                    int responsecode =(int) errorRosponse.StatusCode;
                    Console.WriteLine($"URL: {url.ToString()}  Url is :{"It is a broken link"}   status is :{responsecode}"); //print msg for broken link and url
                }
            }
        }
    }
}


