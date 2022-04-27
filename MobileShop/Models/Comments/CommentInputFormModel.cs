namespace MobileShop.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.Comment;
    public class CommentInputFormModel
    {
        public int PhoneId { get; set; }

        public string SenderEmail { get; set; }

        public string CreatedOn { get; set; }

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Description { get; set; }

        public string UserId { get; set; }
    }
}

