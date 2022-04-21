namespace MobileShop.Models.Dealers
{
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.Dealer;

    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(TownMaxLength, MinimumLength = TownMinLength)]
        public string Town { get; set; }

        [MaxLength(ImageUrlMaxLength)]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
