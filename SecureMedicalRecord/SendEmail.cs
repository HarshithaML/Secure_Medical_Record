using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace SecureMedicalRecord
{
    public class SendEmail
    {
        public static void Send(string EmailID, string Message, string Sub)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("demo.projects.demo@gmail.com", "Mysuru_0009");
            smtp.EnableSsl = true;

            MailAddress _from = new MailAddress("demo.projects.demo@gmail.com");
            MailAddress _to = new MailAddress(EmailID);

            MailMessage mail = new MailMessage(_from, _to);
            mail.Subject = Sub;
            mail.Body = "<font size=15>" + Message + "</font>";
            mail.IsBodyHtml = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}