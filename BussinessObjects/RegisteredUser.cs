using System.ComponentModel.DataAnnotations;

namespace BussinessObjects
{
    public class RegisteredUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email_address { get; set; }
        public string Phone_number { get; set; }
        public string Job_type { get; set; }
        public string Password { get; set; }
        public string FileName { get; set; }

       
    }
}
