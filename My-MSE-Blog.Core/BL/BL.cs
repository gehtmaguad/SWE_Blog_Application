using MyMSEBlog.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSE.SWE.Interfaces;
using MyMSEBlog.Core.Interfaces;
using System.Security;

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
            return _dal.GetUserList().SingleOrDefault(i => i.EMail == email && i.PasswordHash == password) != null ? true : false;
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
            if (IsAdminUser())
            {
                return _dal.GetPostList().Where(obj => obj.IsDeleted == true);
            }
            else
            {
                throw new SecurityException();
            }
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
            if (IsAdminUser())
            {
                return _dal.GetUserList().Where(obj => obj.IsDeleted == true);
            }
            else
            {
                throw new SecurityException();
            }
        }

        public MSE.SWE.Interfaces.IBlogPost GetPost(int id)
        {
            IBlogPost post = _dal.GetPostList().SingleOrDefault(i => i.ID == id);
            if (post.IsDeleted == false || IsAdminUser() == true)
            {
                return post;
            }
            else
            {
                throw new SecurityException();
            }
        }

        public MSE.SWE.Interfaces.IUser GetUser(int id)
        {
            IUser user = _dal.GetUserList().SingleOrDefault(i => i.ID == id);
            if (user.IsDeleted == false || IsAdminUser() == true)
            {
                return user;
            }
            else
            {
                throw new SecurityException();
            }
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

        public bool IsStandardUser(IUser user)
        {
            return System.Threading.Thread.CurrentPrincipal.IsInRole(UserGroup.User.ToString());
        }

        public bool IsAdminUser()
        {
            return System.Threading.Thread.CurrentPrincipal.IsInRole(UserGroup.Admin.ToString());
        }

        public void SaveChanges()
        {
            // TODO: Add some usefull business logic here

            // Delegate save request to the data access layer
            _dal.SaveChanges();
        }
    }
}
