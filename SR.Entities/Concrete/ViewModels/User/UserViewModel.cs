namespace SR.Entities.Concrete.ViewModels.User
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public bool IsPaymentGranted { get; set; }
        public bool IsMailApproved { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public string PlanName { get; set; }
        public string PlanId { get; set; }
        // do not use this on this view model move it to userloginviewmodel smth. like
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
