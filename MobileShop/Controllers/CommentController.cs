namespace MobileShop.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Comments;
    using MobileShop.Domain.Comments.Models;
    using MobileShop.Domain.Phones.ServiceModels;
    using MobileShop.Models.Comments;
    using System;
    using System.Linq;

   
    public class CommentController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICommentService commentService;
        private readonly IPhoneService phoneService;

        public CommentController(
           UserManager<User> userManager,
           ICommentService commentService,
           IPhoneService phoneService)
        {
            this.userManager = userManager;
            this.commentService = commentService;
            this.phoneService = phoneService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All(int id)
        {
            var phone = this.phoneService.Read(id);
            var allComments = this.commentService.FindAll();
            var commentsForPhone = allComments.Where(x => x.PhoneId == id).ToList();

            var phoneCommentViewModel = commentsForPhone.Select(x => new CommentViewModel
            {
                Id = x.Id,
                SenderEmail = this.userManager.FindByIdAsync(x.UserId.ToString()).Result.Email,
                PhoneId = x.PhoneId,
                Description = x.Description,
                CreatedOn = x.CreatedOn                
            }).ToList();

            var phoneComment = new PhoneCommentViewModel
            {
                PhoneId = id,
                ImageUrl = phone.ImageUrl,
                Comments = phoneCommentViewModel
            };

            return View(phoneComment);
        }

        [Authorize]
        public IActionResult Add(int id) 
        {
            return View(new CommentInputFormModel { PhoneId = id });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CommentInputFormModel model)
        {
            var phone = this.phoneService.Read(model.PhoneId);
            var user = this.userManager.GetUserAsync(HttpContext.User).Result;
            var userID = user.Id;

            var comment = new CommentServiceModel
            {
                Description = model.Description,
                PhoneId = phone.Id,
                UserId = userID,
                CreatedOn = DateTime.Now.ToString(),
            };

            this.commentService.Create(comment);

            return RedirectToAction("All", "Comment" ,new { id = model.PhoneId });
        }
    }
}
