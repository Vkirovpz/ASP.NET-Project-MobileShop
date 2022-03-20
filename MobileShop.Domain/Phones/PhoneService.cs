using MobileShop.Data;
using MobileShop.Data.Entities;
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

        public int Create(int brandId, string model, string overview, decimal price, string imageUrl, int categoryId, string color, int dealerId)
        {
            var phoneData = new Phone
            {
                BrandId = brandId,
                Model = model,
                Overview = overview,
                Price = price,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                Color = color,
                DealerId = dealerId
            };

            this.data.Phones.Add(phoneData);

            this.data.SaveChanges();

            return phoneData.Id;
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
