using SR.Entities.Concrete.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SR.Entities.Concrete.DbModels
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public bool IsPaymentGranted { get; set; }
        public bool IsMailApproved { get; set; }
        public DateTime SubscriptionEndDate { get; set; }

        [ForeignKey(nameof(Plan))]
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
