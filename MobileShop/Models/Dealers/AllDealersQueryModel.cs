namespace MobileShop.Models.Dealers
{
    using MobileShop.Domain.Dealers.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.Dealer;
    public class AllDealersQueryModel
    {

        [Display(Name = "Search")]
        [StringLength(DealerSearchTermMaxLength, MinimumLength = DealerSearchTermMinLength)]
        public string SearchTerm { get; init; }

        public IEnumerable<DealerServiceModel> Dealers { get; set; }
    }
}
