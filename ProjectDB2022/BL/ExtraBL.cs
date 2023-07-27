using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ProjectDatabaseOperation;
namespace ProjectDB2022.BL
{
    public class ExtraBL
    {
        projectDBEntities db;
        public ExtraBL()
        {
            db = new projectDBEntities();
        }
    
        public string GeneratePassword(int size)
        {
            string data = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#$";
            string password = "";

            Random r = new Random();
            for (int i = 1; i <= size; i++)
            {
                int p = r.Next(0, data.Length - 1);
                password += data[p];
            }
            return password;
        }
        public string GenerateOTP(int size)
        {
            string data = "0123456789";
            string otp = "";

            Random r = new Random();
            for (int i = 1; i <= size; i++)
            {
                int p = r.Next(0, data.Length - 1);
                otp += data[p];
            }
            return otp;
        }
        public static void Send_Email(string email, string subject, String description)
        {
            var fromAddress = new MailAddress("tanajiwaje5@gmail.com", "Tanaji Waje");
            var toAddress = new MailAddress(email, email);
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = description;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential networkcred = new NetworkCredential();
            networkcred.UserName = "tanajiwaje5@gmail.com";
            networkcred.Password = "jgjiuhwftrotswuc";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkcred;
            smtp.Port = 587;
            smtp.Send(message);
        }

        public static void getPhoto(HttpPostedFileBase file)
        {
           
        }

    }

}