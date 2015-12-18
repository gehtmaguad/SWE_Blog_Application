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
        IDAL _dal;
        public BL(IDAL dal)
        {
            if (dal == null) throw new ArgumentNullException("dal");

            _dal = dal;
        }

        public bool Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MSE.SWE.Interfaces.IBlogPost> GetDeletedPostList()
        {
            throw new NotImplementedException();
        }

        public IQueryable<MSE.SWE.Interfaces.IBlogPost> GetOwnPostList(string email)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MSE.SWE.Interfaces.IBlogPost> GetPostList()
        {
            throw new NotImplementedException();
        }

        public MSE.SWE.Interfaces.IUser GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MSE.SWE.Interfaces.IUser> GetUserList()
        {
            return _dal.GetUserList();
        }

        public MSE.SWE.Interfaces.IBlogPost GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public MSE.SWE.Interfaces.IUser GetUser(int id)
        {
            return _dal.GetUserList().Single(i => i.ID == id);
        }

        public void AddUser(IUser user)
        {
            _dal.AddUser(user);
        }

        public void DeleteUser(IUser user)
        {
            _dal.DeleteUser(user);
        }

        public void SaveChanges()
        {
            // TODO: Add some usefull business logic here

            // Delegate save request to the data access layer
            _dal.SaveChanges();
        }
    }
}
