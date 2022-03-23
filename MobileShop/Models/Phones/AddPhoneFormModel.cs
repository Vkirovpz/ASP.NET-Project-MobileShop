namespace MobileShop.Models.Phones
{
    using MobileShop.Domain.Phones.ServiceModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.Phone;
    public class AddPhoneFormModel
    {
        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; init; }

        public IEnumerable<PhoneBrandServiceModel> Brands { get; set; }

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; init; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; init; }

        [Required]
        [StringLength(OverviewMaxLength, MinimumLength = OverviewMinLength)]
        public string Overview { get; init; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; init; }

        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; init; }    

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PhoneCategoryServiceModel> Categories { get; set; }

        public int DealerId { get; init; }

    }
}
