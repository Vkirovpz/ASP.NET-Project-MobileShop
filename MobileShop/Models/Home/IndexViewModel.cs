namespace MobileShop.Models.Home
{
    using MobileShop.Domain.Phones.ServiceModels;
    using System.Collections.Generic;
    public class IndexViewModel
    {
        public int TotalPhones { get; init; }
        public int TotalUsers { get; init; }
        public IList<PhoneIndexServiceModel> Phones { get; init; }
    }
}
