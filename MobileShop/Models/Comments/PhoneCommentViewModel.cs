namespace MobileShop.Models.Comments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PhoneCommentViewModel
    {

        public int PhoneId { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public List<CommentViewModel> Comments { get; set; }



    }
}
