using MSE.SWE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyMSEBlog.Core.DAL
{
    [XmlRoot("MSEBlogRepo")]
    public class FileRepository
    {
        public List<User> Users { get; set; }
        public List<BlogPost> Posts { get; set; }
    }

    public class User : IUser
    {
        public int ID
        {
            get;
            set;
        }

        public DateTime? BirtDate
        {
            get;
            set;
        }

        public string EMail
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public UserGroup Group
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public bool NeedPasswordReset
        {
            get;
            set;
        }

        public string PasswordHash
        {
            get;
            set;
        }

        public Guid ValidationToken
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }

    public class BlogPost : IBlogPost
    {
        /// <summary>
        /// Used for lazy loading CreatedBy User
        /// </summary>
        internal FileRepository Repo
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        [XmlIgnore]
        public IUser CreatedBy
        {
            get
            {
                return Repo.Users.Single(u => u.ID == CreatedByID);
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value", "CreatedBy cannot be null");
                CreatedByID = value.ID;
            }
        }

        public int CreatedByID
        {
            get;
            set;
        }


        public DateTime CreatedOn
        {
            get;
            set;
        }

        public string Summary
        {
            get;
            set;
        }

        public string Tags
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
