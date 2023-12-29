using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Entities.Concrete.RequestModels.Users
{
    public class UserRegisterRequsetModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public bool IsPaymentGranted { get; set; } = false;
        public bool IsMailApproved { get; set; } = false;
        public DateTime SubscriptionEndDate { get; set; } = DateTime.Now;
    }
}
