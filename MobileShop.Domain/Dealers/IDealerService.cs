﻿namespace MobileShop.Domain.Dealers
{
    public interface IDealerService
    {
        public bool IsDealer(string userId);

        public int IdByUser(string userId);

        public int Create(string name, string phoneNumber, string userId);

    }
}
