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
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            return View(new PhoneFormModel
            {
                Brands = this.phones.GetBrands(),
                Categories = this.phones.GetCategories()
            });
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(PhoneFormModel phone)
        {
            var dealerId = this.dealers.IdByUser(this.User.GetId());

            if (dealerId == 0)
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            if (!ModelState.IsValid)
            {
                phone.Brands = this.phones.GetBrands();
                phone.Categories = this.phones.GetCategories();

                return View(phone);
            }

            this.phones.Create(
                phone.Model,
                phone.Overview,               
                phone.ImageUrl,
                phone.Color,
                phone.Price,
                phone.BrandId,
                phone.CategoryId,
                dealerId
                );

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All([FromQuery] AllPhonesQueryModel query)

        {
            var queryResult = this.phones.All(
                query.Brand,
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                AllPhonesQueryModel.PhonesPerPage);

            query.Brands = this.phones.AllPhoneBrands();
            query.Categories = this.phones.AllPhoneCategories();
            query.TotalPhones = queryResult.TotalPhones;
            query.Phones = queryResult.Phones;

            return View(query);

        }

        [Authorize]
        public IActionResult Mine()
        {
            var myPhones = this.phones.ByUser(this.User.GetId());

            return View(myPhones);
        }


        [Authorize]
        public IActionResult Delete(int id, PhoneServiceModel phone)
        {
            var dealerId = this.dealers.IdByUser(this.User.GetId());

            if (dealerId == 0)
            {
                return RedirectToAction("Become", "Dealers");
            }

            if (!this.phones.isByDealer(id, dealerId))
            {
                return BadRequest();
            }

            this.phones.Delete(phone);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.GetId();

            if (!this.dealers.IsDealer(userId))
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            var phone = this.phones.Details(id);

            if (phone.UserId != userId)
            {
                return Unauthorized();
            }

            return View(new PhoneFormModel
            {
                Model = phone.Model,
                BrandId = phone.BrandId,
                CategoryId = phone.CategoryId,
                Color = phone.Color,
                Overview = phone.Overview,
                ImageUrl = phone.ImageUrl,
                Price = phone.Price,
                Brands = this.phones.GetBrands(),
                Categories = this.phones.GetCategories()
            });

        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, PhoneFormModel phone)
        {
            var dealerId = this.dealers.IdByUser(this.User.GetId());

            if (dealerId == 0)
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");
            }

            if (!this.phones.isByDealer(id, dealerId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                phone.Brands = this.phones.GetBrands();
                phone.Categories = this.phones.GetCategories();

                return View(phone);
            }

             this.phones.Edit(
                id,
                phone.Model,
                phone.Color,
                phone.Overview,
                phone.ImageUrl,
                phone.Price,
                phone.BrandId,
                phone.CategoryId);

            return RedirectToAction(nameof(All));
        }
    }
}
