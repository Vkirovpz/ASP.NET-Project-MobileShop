namespace MobileShop.Domain.Phones.ServiceModels
{
    public class PhoneDetailServiceModel: PhoneServiceModel
    {
        public string Overview { get; init; }

        public int DealerId { get; init; }

        public string DealerName { get; init; }

        public string DealerPhoneNumber { get; init; }
        public string DealerTown { get; init; }

        public string UserId { get; init; }
    }
}
