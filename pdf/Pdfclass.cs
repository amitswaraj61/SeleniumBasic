using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace SeleniumBasicProgram.pdf
{
    public class Pdfclass
    {
        
    public static string ReadPdfContent(string appUrl)
        {
            StringBuilder test = new StringBuilder(); ////used for read pdf in string
            using (PdfReader reader = new PdfReader(appUrl))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    test.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }
            Console.WriteLine(test.ToString());
            Console.WriteLine("Total Length" + test.Length.ToString());
            //     String fileName = "TextFromPDF.txt";

            //     File.WriteAllText(fileName, test.ToString());

            //    System.Diagnostics.Process.Start("TextFromPDF.txt", fileName);

            //     bool result = fileName.Contains("Seeking");
            //     Console.WriteLine("Result is" + result);

            return test.ToString();
        }
    }
}

