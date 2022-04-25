namespace MobileShop.Controllers
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using MobileShop.Models.Email;
    using System;

    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        public ContactController(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _configuration = configuration;
        }

        public IActionResult ContactHost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactHost(EmailInputFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactHost");
            }

                var hostEmail = _configuration.GetValue<string>("UserName");
                _emailSender.SendEmailAsync("phonesValentin@gmail.com", $"This is an email from {model.Email}", model.Message);
                return RedirectToAction("Index", "Home");
        }
    }
}
