using MobileShop.Data;
using MobileShop.Domain.Phones.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Domain.Phones
{
   public class PhoneService : IPhoneService
    {
        private readonly MobileShopDbContext data;

        public PhoneService(MobileShopDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<PhoneBrandServiceModel> GetBrands()
        => this.data
                .Brands
                .Select(b => new PhoneBrandServiceModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();

        public IEnumerable<PhoneCategoryServiceModel> GetCategories()
        => this.data
                .Categories
                .Select(c => new PhoneCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
    }
}
