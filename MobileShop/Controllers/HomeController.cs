namespace MobileShop.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using MobileShop.Domain.Phones.ServiceModels;
    using MobileShop.Domain.Statistics;
    using MobileShop.Models;
    using MobileShop.Models.Home;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IPhoneService phones;
        private readonly IStatisticsService statistics;
        private readonly IMemoryCache cache;

        public HomeController(IPhoneService phones, IStatisticsService statistics, IMemoryCache cache)
        {
            this.phones = phones;
            this.statistics = statistics;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            const string indexPhones = "IndexPhonesCacheKey";

            var phonesToShow = this.cache.Get<IList<PhoneIndexServiceModel>>(indexPhones);

            if (phonesToShow == null)
            {
                phonesToShow = this.phones.AllIndexPhones();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.cache.Set(indexPhones, phonesToShow, cacheOptions);

            }

            var totalStatistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalPhones = totalStatistics.TotalPhones,
                TotalUsers = totalStatistics.TotalUsers,
                Phones = phonesToShow
            });
        }

        public IActionResult Error() => View();
       
    }
}
