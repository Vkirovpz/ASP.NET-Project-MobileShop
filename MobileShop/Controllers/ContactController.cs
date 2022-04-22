namespace MobileShop.Controllers
{
    using Microsoft.AspNetCore.Authorization;
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
                return View("Index");
            }
            try
            {
                var hostEmail = _configuration.GetValue<string>("UserName");
                _emailSender.SendEmailAsync("phonesValentin@gmail.com", $"This is an email from {model.Email}", model.Message);
                this.TempData["Message"] = "Successfully send email !";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("CustomError", "Errors");
            }
        }
    }
}
