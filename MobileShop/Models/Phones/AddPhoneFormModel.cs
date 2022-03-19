using MobileShop.Domain.Phones.ServiceModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models.Phones
{
    public class AddPhoneFormModel
    {
        public string Color { get; init; }

        public string Overview { get; init; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        public decimal Price { get; init; }

        public string Model { get; init; }

        public int DealerId { get; init; }


        [Display(Name = "Brand")]
        public int BrandId { get; init; }

        public IEnumerable<PhoneBrandServiceModel> Brands { get; set; }


        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PhoneCategoryServiceModel> Categories { get; set; }

    }
}
