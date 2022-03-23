namespace MobileShop.Domain.Dealers
{
    using System.Linq;
    using MobileShop.Data;
    using MobileShop.Data.Entities;
    public class DealerService : IDealerService
    {
        private readonly MobileShopDbContext data;

        public DealerService(MobileShopDbContext data)
        {
            this.data = data;
        }

        public int Create(string name, string phoneNumber, string userId)
        {
            var dealerData = new Dealer
            {
                Name = name,
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
    }
}
