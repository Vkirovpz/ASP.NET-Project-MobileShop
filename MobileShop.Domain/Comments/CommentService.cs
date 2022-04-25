namespace MobileShop.Domain.Comments
{
    using Microsoft.EntityFrameworkCore;
    using MobileShop.Data;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Comments.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public bool Delete(CommentServiceModel entity)
        {
            var comment = this.data.Comments.FirstOrDefault(c => c.Id == entity.Id);
            if (comment != null)
            {
                this.data.Comments.Remove(comment);
                this.data.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CommentServiceModel> FindAll()
        {
            try
            {
                var entities = this.data.Comments.AsNoTracking().ToList();
                var comments = entities.Select(e => new CommentServiceModel
                {
                    Id = e.Id,
                    CreatedOn = e.CreatedOn.ToString(),
                    Description = e.Description,
                    UserId = e.UserId,
                    PhoneId = e.PhoneId
                }).ToList();
                return comments;
            }
            catch (Exception)
            {
                return new List<CommentServiceModel>();
            }
        }

        public CommentServiceModel Read(int id)
        {
            var entity = this.data.Comments.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                return new CommentServiceModel
                {
                    Id = entity.Id,
                    CreatedOn = entity.CreatedOn.ToString(),
                    Description = entity.Description,
                    UserId = entity.UserId,
                    PhoneId = entity.PhoneId
                };
            }
            return null;
        }

        public bool Update(CommentServiceModel entity)
        {
            try
            {
                var comment = new Comment
                {
                    Id = entity.Id,
                    CreatedOn = DateTime.Parse(entity.CreatedOn),
                    Description = entity.Description,
                    UserId = entity.UserId,
                    PhoneId = entity.PhoneId
                };
                this.data.Comments.Update(comment);
                this.data.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
