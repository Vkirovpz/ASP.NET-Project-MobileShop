namespace MobileShop.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Domain.Phones.ServiceModels;

    public class PhonesController : AdminController
    {
        private readonly IPhoneService phones;

        public PhonesController(IPhoneService phones) => this.phones = phones;

        public IActionResult All()
        {
            var phones = this.phones.All().Phones;

            return View(phones);
        }

    }
}
