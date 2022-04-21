namespace MobileShop.Domain.Dealers.Models
{
    public class DealerServiceModel
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Town { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }

    }
}
