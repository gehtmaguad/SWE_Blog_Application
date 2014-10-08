using MyMSEBlog.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSE.SWE.Interfaces;

namespace MyMSEBlog.Core.BL
{
    public class BL : IBL
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

        public IQueryable<MSE_SWE.Interfaces.IBlogPost> GetDeletedPostList()
        {
            throw new NotImplementedException();
        }

        public IQueryable<MSE_SWE.Interfaces.IBlogPost> GetOwnPostList(string email)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MSE_SWE.Interfaces.IBlogPost> GetPostList()
        {
            throw new NotImplementedException();
        }

        public MSE_SWE.Interfaces.IUser GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MSE_SWE.Interfaces.IUser> GetUserList()
        {
            return _dal.GetUserList();
        }

        public MSE_SWE.Interfaces.IBlogPost GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public MSE_SWE.Interfaces.IUser GetUser(int id)
        {
            return _dal.GetUserList().Single(i => i.ID == id);
        }
    }
}
