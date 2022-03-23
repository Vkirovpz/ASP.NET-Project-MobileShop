namespace MobileShop.Domain.Phones.ServiceModels
{
    using System.Collections.Generic;
    public interface IPhoneService
    {
        public IEnumerable<PhoneBrandServiceModel> GetBrands();

        IEnumerable<string> AllPhoneBrands();

        IEnumerable<string> AllPhoneCategories();

        public IEnumerable<PhoneCategoryServiceModel> GetCategories();

        public IList<PhoneIndexServiceModel> AllIndexPhones();
        public int TotalPhones();
        public int TotalUsers();

        public int Create(
               int brandId,
               string model,
               string overview,
               decimal price,
               string imageUrl,
               int conditionId,
               string color,
               int dealerId);

        PhoneQueryServiceModel All(
            string brand,
            string category,
            string searchTerm,
            int currentPage,
            int phonesPerPage);

     
    }
}
