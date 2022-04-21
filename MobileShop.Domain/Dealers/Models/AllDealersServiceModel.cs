namespace MobileShop.Domain.Dealers
{
    using MobileShop.Domain.Dealers.Models;
    using System.Collections.Generic;
    public class AllDealersServiceModel
    {
        public int CurrentPage { get; init; }

        public int DealersPerPage { get; init; }

        public int TotalDealers { get; init; }

        public IEnumerable<DealerServiceModel> Dealers { get; init; }
    }
}
