using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Entities.Concrete.RequestModels.Users
{
    public class UserLoginRequestModel
    {
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }
}
