namespace MobileShop.Domain.Phones.ServiceModels
{
    using System.Collections.Generic;
    public class PhoneQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int PhonesPerPage { get; init; }

        public int TotalPhones { get; init; }

        public IEnumerable<PhoneServiceModel> Phones { get; init; }
    }
}
