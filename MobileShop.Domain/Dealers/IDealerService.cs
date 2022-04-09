﻿namespace MobileShop.Domain.Dealers
{
    public interface IDealerService
    {
        bool IsDealer(string userId);

        int IdByUser(string userId);

        int Create(string name, string phoneNumber, string userId);

    }
}
