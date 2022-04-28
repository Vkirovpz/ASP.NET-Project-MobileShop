namespace MobileShop.Models.Email
{
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.EmailFormModel;
    public class EmailInputFormModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(ContactNameMaxLength, MinimumLength = ContactNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(SubjectMaxLength, MinimumLength = SubjectMinLength)]
        public string Subject { get; set; }

        [Required]
        [StringLength(MessageMaxLength, MinimumLength = MessageMinLength)]
        public string Message { get; set; }
    }
}
