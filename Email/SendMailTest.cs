using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace SeleniumBasicProgram.Email
{
    public class SendMailTest
    {
        public static void SendEmail(String Subject, String contentBody)
        {
            MailMessage mail = new MailMessage();
            String fromEmail = "Aswaraj78@gmail.com";
            String password = "123456qwe789";
            String ToEmail = "amitswaraj450@gmail.com";
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(ToEmail);
            mail.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            mail.Body = contentBody;
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(@"C:/Users/Kis/source/repos/SeleniumBasicProgram/SeleniumBasicProgram/Report/index.html"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmail, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }


    }
    }

           
            

           

            


        
   
