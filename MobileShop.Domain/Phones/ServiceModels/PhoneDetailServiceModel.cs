namespace MobileShop.Domain.Phones.ServiceModels
{
    public class PhoneDetailServiceModel: PhoneServiceModel
    {
        public string Overview { get; init; }

        public int DealerID { get; init; }

        public string DealerName { get; init; }

        public string UserID { get; init; }
    }
}
