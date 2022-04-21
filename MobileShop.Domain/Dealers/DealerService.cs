namespace MobileShop.Domain.Dealers
{
    using System.Collections.Generic;
    using System.Linq;
    using MobileShop.Data;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Dealers.Models;

    public class DealerService : IDealerService
    {
        private readonly MobileShopDbContext data;

        public DealerService(MobileShopDbContext data)
        {
            this.data = data;
        }

        public int Create(string name,string town, string imageUrl, string phoneNumber, string userId)
        {
            var dealerData = new Dealer
            {
                Name = name,
                Town = town,
                ImageUrl = imageUrl,
                PhoneNumber = phoneNumber,
                UserId = userId
            };

            this.data.Dealers.Add(dealerData);
            this.data.SaveChanges();
            return dealerData.Id;
        }

        public int IdByUser(string userId)
        => this.data
                .Dealers
                .Where(d => d.UserId == userId)
                .Select(d => d.Id)
                .FirstOrDefault();


        public bool IsDealer(string userId)
        => this.data
            .Dealers
            .Any(d => d.UserId == userId);

        private IEnumerable<DealerServiceModel> GetDealers(IQueryable<Dealer> dealerQuery)
            => dealerQuery
            .Select(d => new DealerServiceModel()
            {
                Id = d.Id,
                Name = d.Name,
                PhoneNumber = d.PhoneNumber,         
            }).ToList();

        public AllDealersServiceModel All(
           string searchTerm = null)
        {
            var dealersQuery = this.data.Dealers.AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                dealersQuery = dealersQuery
                    .Where(d => d.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalDealers= dealersQuery.Count();

            var dealers = GetDealers(dealersQuery);

            return new AllDealersServiceModel
            {
                Dealers = dealers
            };
        }

    }
}
