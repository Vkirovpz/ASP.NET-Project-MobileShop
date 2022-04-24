namespace MobileShop.Domain.Phones.ServiceModels
{
    public class PhoneServiceModel
    {
        public int Id { get; init; }
       
        public int BrandId { get; init; }

        public string BrandName { get; init; }

        public int CategoryId { get; init; }

        public string CategoryName { get; init; }

        public string Model { get; init; }

        public string Color { get; init; }

        public string ImageUrl { get; init; }

        public decimal Price { get; init; }
    }
}
