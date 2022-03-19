using MobileShop.Data;
using System;
using System.Linq;

namespace MobileShop.Domain.Dealers
{
    public class DealerService : IDealerService
    {
        private readonly MobileShopDbContext data;

        public DealerService(MobileShopDbContext data)
        {
            this.data = data;
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
