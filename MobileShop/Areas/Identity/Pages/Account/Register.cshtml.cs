namespace MobileShop.Areas.Identity.Pages.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Comments;
    using MobileShop.Domain.Comments.Models;
    using static Data.DataConstants.User;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IEmailSender emailSender;
        private readonly ICommentService commentService;
        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            ICommentService commentService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.commentService = commentService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Display(Name = "Full Name")]
            [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
            public string FullName { get; set; }

            [Required]
            [StringLength(PassswordMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = PassswordMinLength)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FullName = Input.FullName
                };

                var result = await this.userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await this.emailSender.SendEmailAsync(user.Email, "Registration", "Welcome to valentin's site :");
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
