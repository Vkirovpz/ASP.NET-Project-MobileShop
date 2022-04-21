namespace MobileShop.Domain.Dealers.Models
{
    using MobileShop.Data.Entities;
    public class DealerServiceModel
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
