namespace SR.Entities.Concrete.RequestModels.Users
{
    public class UserUpdateRequestModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public int PlanId { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool IsPaymentGranted { get; set; }
        public bool IsMailApproved { get; set; }
    }
}
