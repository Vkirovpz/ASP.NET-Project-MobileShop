namespace MobileShop.Domain.Phones.ServiceModels
{
    using System.Collections.Generic;
    public class IndexServiceModel
    {
        public int TotalPhones { get; init; }
        public int TotalUsers { get; init; }
        public IList<PhoneIndexServiceModel> Phones { get; init; }
    }
}
