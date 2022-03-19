using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models.Phones
{
    public class PhoneSearchQueryModel
    {
        public const int PhonesPerPage = 3;

        public int CurrentPage { get; init; } = 1;

        public int TotalPhones { get; set; }

        public string Brand { get; init; }


        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public IEnumerable<string> Brands { get; set; }

        //public IEnumerable<PhoneServiceModel> Phones { get; set; }
    }
}
