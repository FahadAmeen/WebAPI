using System;
using System.Collections;
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
using WebApiProject.Data;
using WebApiProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.ExceptionServices;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class emailController : ControllerBase
    {
        private MailMessage message = new MailMessage();
        private string resetPasswordLink = "http://localhost:4200/resetpassword?userEmail=";
        private DBContext _context; 

        public emailController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<bool> sendEmailAsync(string to)
        {
            //First checking if this emailController has as Valid reset duration------
            List<ResetPassword> allMatchingRecords;
            allMatchingRecords = _context.ResetPassword.Where(s => s.userEmail == to).ToList();
            ResetPassword newRecord;

            if (allMatchingRecords.Count() < 1) //create new entry to validate reset request
            {
                newRecord = new ResetPassword();
                newRecord.userEmail = to;
                newRecord.resetRequestTime  = DateTime.Now;
                newRecord.expiryTime = newRecord.resetRequestTime.AddDays(1);
                _context.ResetPassword.Add(newRecord);
                await _context.SaveChangesAsync();
            }
            else
            {
                allMatchingRecords = allMatchingRecords.OrderBy(item => item.resetRequestTime).ToList();
                var latestLoginRecord = allMatchingRecords[allMatchingRecords.Count() - 1];
                if (latestLoginRecord.expiryTime < DateTime.Now)
                {
                    newRecord = new ResetPassword();
                    newRecord.userEmail = to;
                    newRecord.resetRequestTime = DateTime.Now;
                    newRecord.expiryTime = newRecord.resetRequestTime.AddDays(1);
                    _context.ResetPassword.Add(newRecord);
                    await _context.SaveChangesAsync();
                }
            }

            if (userExists(to))
            {
                MailboxAddress from = new MailboxAddress("Admin", "blahb8818@gmail.com");
                message.To.Add(new MailAddress(to, "Ma'am/Mr."));
                message.From = new MailAddress("blahb8818@gmail.com", "My first website");

                message.Subject = "Password Reset";
                message.Body = "Hello Beautiful :D, Please click the link below to reset your password " +
                               this.resetPasswordLink+to;
                message.IsBodyHtml = true;

                // == Generating token 
               
                //===================

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
            //means the user email is invalid or no account has been created on this email
            return false;
        }


        public bool userExists(string userEmail)
        {
            var selectUsers = from s in _context.Login select s;

            if (!String.IsNullOrEmpty(userEmail) && !(userEmail == null))
            {
                //got all users with the current user name 
                var matchingUsers = selectUsers.Where(s => s.UserEmail == userEmail).ToList();
                if (matchingUsers.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }


    }
}