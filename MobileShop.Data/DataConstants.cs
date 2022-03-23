namespace MobileShop.Data
{
   public class DataConstants
   {
       public class Phone
       {
           
           public const int ImageUrlMaxLength = 300;
           public const int ColorMaxLength = 20;
           public const int ColorMinLength = 3;
           public const int OverviewMaxLength = 500;
           public const int OverviewMinLength = 10;
           public const int MinPrice = 1;
           public const int MaxPrice = 10000;
           public const int ModelMaxLength = 20;
           public const int ModelMinLength = 2;
        }

       public class Brand
       {
           public const int BrandMaxLength = 20;
           public const int BrandMinLength = 2;
       }

        public class Dealer
        {
           public const int NameMaxLength = 25;
           public const int NameMinLength = 2;
           public const int PhoneNumberMaxLength = 30;
           public const int PhoneNumberMinLength = 5;
        }

        public class User
        {
            public const int FullNameMaxLength = 40;
            public const int FullNameMinLength = 5;
            public const int PassswordMaxLength = 100;
            public const int PassswordMinLength = 6;
        }
       
   }
}
