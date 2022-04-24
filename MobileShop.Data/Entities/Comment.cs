namespace MobileShop.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.Comment;
    public class Comment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Description { get; set; }

        public int PhoneId { get; set; }

        public Phone Phone { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
