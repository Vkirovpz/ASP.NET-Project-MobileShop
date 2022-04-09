namespace MobileShop.Models.Phones
{
    using MobileShop.Domain.Phones.ServiceModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AllPhonesQueryModel
    {
        public const int PhonesPerPage = 6;

        public int CurrentPage { get; init; } = 1;

        public int TotalPhones { get; set; }

        public string Brand { get; init; }

        public string Category { get; init; }


        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public IEnumerable<string> Brands { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<PhoneServiceModel> Phones { get; set; }
    }
}
