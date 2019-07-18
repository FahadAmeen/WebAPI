using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Emit;
using WebApiProject.Helper_classes;

namespace WebApiProject.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }

        //to help encryptor encrypt password
        public string stringPassword;

        public Login()
        {

        }

        public Login(string username, string psStringPassword)
        {
            UserName = username;
            stringPassword = psStringPassword;
            
          // this.Password = Encryptor.EncryptStringToBytes_Aes(stringPassword);
           this.Password = Encryptor.Encrypt(stringPassword);
        }
    }
}
