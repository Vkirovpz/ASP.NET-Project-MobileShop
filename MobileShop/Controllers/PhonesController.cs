using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Domain.Dealers;
using MobileShop.Domain.Phones.ServiceModels;
using MobileShop.Models.Phones;

namespace MobileShop.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IPhoneService phones;
        private readonly IDealerService dealers;

        public PhonesController(IPhoneService phones, IDealerService dealers)
        {
            this.phones = phones;
            this.dealers = dealers;
        }

        [Authorize]
        public IActionResult Add()
        {
            //if (!this.dealers.IsDealer(this.User.GetId()))
            //{
            //    return RedirectToAction(nameof(DealersController.Become), "Dealers");
            //}

            return View(new AddPhoneFormModel
            {
                Brands = this.phones.GetBrands(),
                Categories = this.phones.GetCategories()
            });
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPhoneFormModel phone)
        {
            return View();
        }
        
    }
}
