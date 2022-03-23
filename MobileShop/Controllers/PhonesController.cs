namespace MobileShop.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Domain.Dealers;
    using MobileShop.Domain.Phones.ServiceModels;
    using MobileShop.Infrastructure;
    using MobileShop.Models.Phones;
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
            if (!this.dealers.IsDealer(this.User.GetId()))
            {
                return RedirectToAction("Become", "Dealers");
            }

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

        public IActionResult All([FromQuery] PhoneSearchQueryModel query)

        {
            var queryResult = this.phones.All(
                query.Brand,
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                PhoneSearchQueryModel.PhonesPerPage);


            var phoneBrands = this.phones.AllPhoneBrands();
            var phoneCategories = this.phones.AllPhoneCategories();

            query.Brands = phoneBrands;
            query.Categories = phoneCategories;
            query.TotalPhones = queryResult.TotalPhones;
            query.Phones = queryResult.Phones;

            return View(query);

        }

    }
}
