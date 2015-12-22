using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSE.SWE.Interfaces;

namespace MyMSEBlog.Core.Interfaces
{
    public interface MyIBL : IBL
    {
        /// <summary>
        /// Adds a new User
        /// </summary>
        void AddUser(IUser user);

        /// <summary>
        /// Deletes an existing User
        /// </summary>
        void DeleteUser(IUser user);

        /// <summary>
        /// Adds a new User
        /// </summary>
        void AddPost(IBlogPost blogPost);

        /// <summary>
        /// Adds a new User
        /// </summary>
        void DeletePost(IBlogPost blogPost);
    }
}
