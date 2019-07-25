using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net;
using System.Net.Mail;


namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class emailController : ControllerBase
    {
        private MailMessage message = new MailMessage();

        public emailController()
        {

        }

        [HttpGet]
        public bool sendEmail(string emailContent)
        {

            MailboxAddress from = new MailboxAddress("Admin", "blahb8818@gmail.com");
            message.To.Add(new MailAddress("rima@ciklum.com", "rida"));
            message.From = new MailAddress("blahb8818@gmail.com", "My first website");
           
            message.Subject = "Password Reset";
            message.Body = "Please click the link below to reset your password "+emailContent;
            message.IsBodyHtml = true;

            // ==== SMTP access
            using (var client = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("blahb8818@gmail.com", "blah?_B_blah1");
                client.EnableSsl = true;
                client.Send(message);
            }

            return true;
        }

    }
}