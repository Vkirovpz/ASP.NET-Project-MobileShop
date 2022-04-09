namespace MobileShop.Models.Api.Phones
{
    public class AllPhonesApiRequestModel
    {
        public string Brand { get; init; }

        public string Category { get; init; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int PhonesPerPage { get; init; } = 6;
    }
}
