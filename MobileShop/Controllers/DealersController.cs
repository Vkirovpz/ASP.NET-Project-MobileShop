namespace MobileShop.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Domain.Dealers;
    using MobileShop.Infrastructure;
    using MobileShop.Models.Dealers;
    public class DealersController : Controller
    {
        private readonly IDealerService dealers;

        public DealersController(IDealerService dealers)
        => this.dealers = dealers;
        

        [Authorize]
        public IActionResult Become() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeDealerFormModel dealer)
        {
            var userId = this.User.GetId();

            if (dealers.IsDealer(userId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            dealers.Create(dealer.Name,dealer.Town, dealer.ImageUrl, dealer.PhoneNumber, userId);

            return RedirectToAction(nameof(DealersController.All), "Dealers");

        }

        public IActionResult All([FromQuery] AllDealersQueryModel query)

        {
            if (!ModelState.IsValid)
            {
                return View("All");
            }
            var queryResult = this.dealers.All(query.SearchTerm);

            query.Dealers = queryResult.Dealers;

            return View(query);

        }
    }
}
