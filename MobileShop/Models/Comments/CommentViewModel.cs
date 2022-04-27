namespace MobileShop.Models.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public int PhoneId { get; set; }

        public string Description { get; set; }

        public string SenderEmail { get; set; }

        public string CreatedOn { get; set; }

        public string UserId { get; set; }
    }
}
