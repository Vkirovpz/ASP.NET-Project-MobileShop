namespace MobileShop.Domain.Comments.Models
{
    public class CommentServiceModel
    {
        public int Id { get; set; }

        public int PhoneId { get; set; }

        public string PhoneName { get; set; }

        public string Description { get; set; }

        public string SenderEmail { get; set; }

        public string CreatedOn { get; set; }

        public string UserId { get; set; }
    }
}
