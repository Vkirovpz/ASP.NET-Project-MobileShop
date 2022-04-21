namespace MobileShop.Domain.Dealers.Models
{
    using System.Collections.Generic;
    public class AllDealersServiceModel
    {
        public IEnumerable<DealerServiceModel> Dealers { get; init; }
    }
}
