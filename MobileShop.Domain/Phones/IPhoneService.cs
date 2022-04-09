namespace MobileShop.Domain.Phones.ServiceModels
{
    using System.Collections.Generic;
    public interface IPhoneService
    {
        IEnumerable<PhoneBrandServiceModel> GetBrands();

        IEnumerable<string> AllPhoneBrands();

        IEnumerable<string> AllPhoneCategories();

        IEnumerable<PhoneCategoryServiceModel> GetCategories();

        IList<PhoneIndexServiceModel> AllIndexPhones();

        int Create(
               
               string model,
               string overview,
               string imageUrl,
               string color,
               decimal price,
               int brandId,
               int categoryId,
               int dealerId);

        PhoneQueryServiceModel All(
            string brand,
            string category,
            string searchTerm,
            int currentPage,
            int phonesPerPage);

        IEnumerable<PhoneServiceModel> ByUser(string userId);
        PhoneDetailServiceModel Details(int phoneId);

        bool Edit(
            int id,
            string model,
            string color,
            string overview,
            string imageUrl,
            decimal price,
            int brandId,
            int categoryId);
           

        void Delete(PhoneServiceModel phone);

        bool isByDealer(int phoneId, int dealerId);
    }
}
