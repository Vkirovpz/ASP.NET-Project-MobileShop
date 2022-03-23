namespace MobileShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Domain.Phones.ServiceModels;
    using MobileShop.Models;
    using MobileShop.Models.Home;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly IPhoneService phones;

        public HomeController(IPhoneService phones)
        {
            this.phones = phones;
        }

        public IActionResult Index()
        {
            var totalPhones = this.phones.TotalPhones();
            var totalUsers = this.phones.TotalUsers();
            var phonesToShow = this.phones.AllIndexPhones();

            return View(new IndexViewModel
            {
                TotalPhones = totalPhones,
                TotalUsers = totalUsers,
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
