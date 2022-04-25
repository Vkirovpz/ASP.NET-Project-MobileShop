namespace MobileShop.Domain.Comments
{
    using MobileShop.Data;
    using MobileShop.Domain.Comments.Models;
    using System.Collections.Generic;
    public class CommentService : ICommentService
    {
        private readonly MobileShopDbContext data;
        public int Create(CommentServiceModel comment)
        {
            throw new System.NotImplementedException();
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
