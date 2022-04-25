namespace MobileShop.Domain.Comments
{
    using MobileShop.Data;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Comments.Models;
    using System;
    using System.Collections.Generic;
    public class CommentService : ICommentService
    {
        private readonly MobileShopDbContext data;
        public CommentService(MobileShopDbContext data)
        {
            this.data = data;
        }

        public int Create(CommentServiceModel entity)
        {
            var comment = new Comment
            {
                PhoneId = entity.PhoneId,
                Description = entity.Description,
                CreatedOn = DateTime.Parse(entity.CreatedOn),
                UserId = entity.UserId
            };

            this.data.Comments.Add(comment);
            this.data.SaveChanges();
            return entity.Id;

        }

        public bool Delete(CommentServiceModel comment)
        {
            throw new System.NotImplementedException();
        }

        public List<CommentServiceModel> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public CommentServiceModel Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(CommentServiceModel comment)
        {
            throw new System.NotImplementedException();
        }
    }
}
