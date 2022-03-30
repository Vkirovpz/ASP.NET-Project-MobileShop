namespace MobileShop.Domain.Statistics
{
    using MobileShop.Data;
    using System.Linq;
    public class StatisticsService : IStatisticsService
    {
        private readonly MobileShopDbContext data;

        public StatisticsService(MobileShopDbContext data) => this.data = data;

        public StatisticsServiceModel Total()
        {
            var totalPhones = this.data.Phones.Count();
            var totalUsers = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalPhones = totalPhones,
                TotalUsers = totalUsers
            };
        }
    }
}
