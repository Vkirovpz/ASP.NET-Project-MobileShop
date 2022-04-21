namespace MobileShop.Domain.Phones
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MobileShop.Data;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Phones.ServiceModels;
    using System.Collections.Generic;
    using System.Linq;
    public class PhoneService : IPhoneService
    {
        private readonly MobileShopDbContext data;
        private readonly IMapper mapper;

        public PhoneService(MobileShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
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

        public IEnumerable<string> AllPhoneCategories()
       => this.data
               .Phones
               .Select(p => p.Category.Name)
               .Distinct()
               .ToList();

        private IEnumerable<PhoneServiceModel> GetPhones(IQueryable<Phone> phoneQuery)
            => phoneQuery
            .Select(p => new PhoneServiceModel()
            {
                Id = p.Id,
                BrandName = p.Brand.Name,
                Model = p.Model,
                Color = p.Color,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                CategoryName = p.Category.Name
            }).ToList();

        public IList<PhoneIndexServiceModel> AllIndexPhones()
        {
            var phones = this.data
                .Phones
                .ProjectTo<PhoneIndexServiceModel>(this.mapper.ConfigurationProvider)
                .OrderByDescending(p => p.Id)
                .Take(5)
                .ToList();

            return phones;
        }

        public PhoneQueryServiceModel All(
            string brand = null,
            string category = null,
            string searchTerm = null,
            int currentPage = 1,
            int phonesPerPage = int.MaxValue)
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

        public IEnumerable<PhoneServiceModel> ByUser(string userId)
        => GetPhones(this.data.Phones
            .Where(p => p.Dealer.UserId == userId));

        public PhoneDetailServiceModel Details(int phoneId)
        => this.data
            .Phones
            .Where(p => p.Id == phoneId)
            .ProjectTo<PhoneDetailServiceModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();

        public bool Edit(int id, string model, string color, string overview, string imageUrl, decimal price, int brandId, int categoryId)
        {
            var phoneData = this.data.Phones.Find(id);

            if (phoneData == null)
            {
                return false;
            }

            phoneData.BrandId = brandId;
            phoneData.CategoryId = categoryId;
            phoneData.Model = model;
            phoneData.Color = color;
            phoneData.Overview = overview;
            phoneData.ImageUrl = imageUrl;
            phoneData.Price = price;

            this.data.SaveChanges();

            return true;
        }

        public void Delete(PhoneServiceModel phone)
        {
            var phoneData = this.data.Phones
                .Where(p => p.Id == phone.Id)
                .FirstOrDefault();

            this.data.Phones.Remove(phoneData);
            this.data.SaveChanges();
        }

        public bool isByDealer(int phoneId, int dealerId)
        => this.data.Phones
            .Any(p => p.Id == phoneId && p.DealerId == dealerId);

        public int Create(string model, string overview, string imageUrl, string color, decimal price, int brandId, int categoryId, int dealerId)
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
    }
}
