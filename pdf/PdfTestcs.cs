using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasicProgram.pdf
{

    public class PdfTestcs
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void VerifyPDFContent()
        {
            try
            {
                string source = "http://www.africau.edu/images/default/sample.pdf";
                driver.Url = source;
                String pdfContent = Pdfclass.ReadPdfContent(driver.Url);

                Assert.IsTrue(pdfContent.Contains("This is a small demonstration .pdf file"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
