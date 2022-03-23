namespace MobileShop.Domain.Phones
{
    using MobileShop.Data;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Phones.ServiceModels;
    using System.Collections.Generic;
    using System.Linq;
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

        public IEnumerable<string> AllPhoneBrands()
            => this.data
                .Phones
                .Select(p => p.Brand.Name)
                .Distinct()
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

        private IEnumerable<PhoneServiceModel> GetPhones(IQueryable<Phone> phoneQuery)
            => phoneQuery
            .Select(p => new PhoneServiceModel()
            {
                Id = p.Id,
                Brand = p.Brand.Name,
                Model = p.Model,
                ImageUrl = p.ImageUrl
            }).ToList();

        public IList<PhoneIndexServiceModel> AllIndexPhones()
        {
            var phones = this.data.Phones
                .Select(p => new PhoneIndexServiceModel
                {
                    Id = p.Id,
                    Brand = p.Brand.Name,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl
                })
                .OrderBy(p=> p.Id)
                .Take(3)
                .ToList();

            return phones;
        }

        public int TotalPhones()
        {
            var total = this.data.Phones.Count();
            return total;
        }

        public int TotalUsers()
        {
            var total = this.data.Users.Count();
            return total;
        }

        public PhoneQueryServiceModel All(string brand,string category, string searchTerm, int currentPage, int phonesPerPage)
        {
            var phonesQuery = this.data.Phones.AsQueryable();


            if (!string.IsNullOrWhiteSpace(brand))
            {
                phonesQuery = phonesQuery
                    .Where(p => p.Brand.Name == brand);
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                phonesQuery = phonesQuery
                    .Where(p => p.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                phonesQuery = phonesQuery
                    .Where(p =>
                        p.Brand.Name.ToLower().Contains(searchTerm.ToLower()) ||
                        p.Model.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalPhones = phonesQuery.Count();

            var phones = GetPhones(phonesQuery
                .Skip((currentPage - 1) * phonesPerPage)
                .Take(phonesPerPage));

            return new PhoneQueryServiceModel
            {
                TotalPhones = totalPhones,
                CurrentPage = currentPage,
                PhonesPerPage = phonesPerPage,
                Phones = phones
            };
        }

        public IEnumerable<string> AllPhoneCategories()
        => this.data
                .Phones
                .Select(p => p.Category.Name)
                .Distinct()
                .ToList();
    }
}
