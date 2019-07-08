using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models.Wrappers
{
    public class UserModelInfoWrapper
    {
        public int count { get; set; }
        public List<UserModel> data { get; set; }
    }
}
