namespace MobileShop.Models.Dealers
{
    using MobileShop.Domain.Dealers.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class AllDealersQueryModel
    {

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public IEnumerable<DealerServiceModel> Dealers { get; set; }
    }
}
