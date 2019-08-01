using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Helper;

namespace WebApiProject.Models
{
    public class UserLogin
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string Password;
        public byte[] SPassword { get; set; }

        //to help encryptor encrypt password
 

        public UserLogin()
        {

        }

        public UserLogin(string useremail, string psStringPassword)
        {
            email = useremail;
            Password = psStringPassword;

            // this.Password = Encryptor.EncryptStringToBytes_Aes(stringPassword);
            this.SPassword = EncryptDecrpt.Encrypt(Password);
        }

    }
}
