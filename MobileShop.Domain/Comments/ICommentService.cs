namespace MobileShop.Domain.Comments
{
    using MobileShop.Domain.Comments.Models;
    using System.Collections.Generic;
    public interface ICommentService
    {
        public int Create(CommentServiceModel comment);


        public bool Delete(CommentServiceModel comment);


        public List<CommentServiceModel> FindAll();


        public CommentServiceModel Read(int id);


        public bool Update(CommentServiceModel comment);

    
    }
}
