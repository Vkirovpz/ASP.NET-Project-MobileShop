namespace MobileShop.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Domain.Phones.ServiceModels;
    using MobileShop.Domain.Statistics;
    using MobileShop.Models;
    using MobileShop.Models.Home;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly IPhoneService phones;
        private readonly IStatisticsService statistics;

        public HomeController(IPhoneService phones, IStatisticsService statistics)
        {
            this.phones = phones;
            this.statistics = statistics;
        }

        public IActionResult Index()
        {
            var totalStatistics = this.statistics.Total();
            var phonesToShow = this.phones.AllIndexPhones();

            return View(new IndexViewModel
            {
                TotalPhones = totalStatistics.TotalPhones,
                TotalUsers = totalStatistics.TotalUsers,
                Phones = phonesToShow
            });
        }
   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
