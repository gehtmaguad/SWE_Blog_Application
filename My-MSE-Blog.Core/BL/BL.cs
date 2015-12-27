using MyMSEBlog.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSE.SWE.Interfaces;
using MyMSEBlog.Core.Interfaces;

namespace MyMSEBlog.Core.BL
{
    public class BL : MyIBL
    {
        readonly IDAL _dal;

        public BL(IDAL dal)
        {
            if (dal == null) throw new ArgumentNullException("dal");

            _dal = dal;
        }

        public bool Authenticate(string email, string password)
        {
            bool test = _dal.GetUserList().SingleOrDefault(i => i.EMail == email && i.PasswordHash == password) != null ? true : false;
            return test;
        }

        public IQueryable<MSE.SWE.Interfaces.IBlogPost> GetOwnPostList(string email)
        {
            return _dal.GetPostList().Where(obj => obj.CreatedBy.EMail == email);
        }

        public IQueryable<MSE.SWE.Interfaces.IBlogPost> GetPostList()
        {
            return _dal.GetPostList().Where(obj => obj.IsDeleted == false);
        }

        public IQueryable<MSE.SWE.Interfaces.IBlogPost> GetDeletedPostList()
        {
            return _dal.GetPostList().Where(obj => obj.IsDeleted == true);
        }

        public MSE.SWE.Interfaces.IUser GetUser(string email)
        {
            return _dal.GetUserList().SingleOrDefault(i => i.EMail == email);
        }

        public IQueryable<MSE.SWE.Interfaces.IUser> GetUserList()
        {
            return _dal.GetUserList().Where(obj => obj.IsDeleted == false);
        }

        public IQueryable<MSE.SWE.Interfaces.IUser> GetDeletedUserList()
        {
            return _dal.GetUserList().Where(obj => obj.IsDeleted == true);
        }

        public MSE.SWE.Interfaces.IBlogPost GetPost(int id)
        {
            return _dal.GetPostList().SingleOrDefault(i => i.ID == id);
        }

        public MSE.SWE.Interfaces.IUser GetUser(int id)
        {
            return _dal.GetUserList().SingleOrDefault(i => i.ID == id);
        }

        public void AddUser(IUser user)
        {
            _dal.AddUser(user);
        }

        public void AddPost(IBlogPost blogPost)
        {
            _dal.AddPost(blogPost);
        }

        public void DeleteUser(IUser user)
        {
            _dal.DeleteUser(user);
        }

        public void DeletePost(IBlogPost blogPost)
        {
            _dal.DeletePost(blogPost);
        }

        public void SaveChanges()
        {
            // TODO: Add some usefull business logic here

            // Delegate save request to the data access layer
            _dal.SaveChanges();
        }
    }
}
