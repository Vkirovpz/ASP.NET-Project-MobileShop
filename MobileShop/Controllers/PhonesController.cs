using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Domain.Dealers;
using MobileShop.Domain.Phones.ServiceModels;
using MobileShop.Infrastructure;
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
            //if (!this.dealers.IsDealer(this.user.getid()))
            //{
            //    return redirecttoaction(nameof(dealerscontroller.become), "dealers");
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
            var dealerId = this.dealers.IdByUser(this.User.GetId());

            if (!ModelState.IsValid)
            {
                phone.Brands = this.phones.GetBrands();
                phone.Categories = this.phones.GetCategories();

                return View(phone);
            }

            this.phones.Create(
                phone.BrandId,
                phone.Model,
                phone.Overview,
                phone.Price,
                phone.ImageUrl,
                phone.CategoryId,
                phone.Color,
                dealerId
                );

            return RedirectToAction("Index", "Home");
        }

    }
}
