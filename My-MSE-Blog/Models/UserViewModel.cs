using MSE.SWE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMSEBlog.Models
{
    public class UserViewModel : IUserViewModel
    {
        public UserViewModel()
        {

        }

        public UserViewModel(IUser mdl)
        {
            // TODO: Complete member initialization
        }

        public DateTime? BirtDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ChangePassword
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ChangePasswordRepeat
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string DisplayName
        {
            get { throw new NotImplementedException(); }
        }

        public string EMail
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string FirstName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public UserGroup Group
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> Groups
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int ID
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDeleted
        {
            get { throw new NotImplementedException(); }
        }

        public string LastName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string MiddleName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool NeedPasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Guid ValidationToken
        {
            get { throw new NotImplementedException(); }
        }
    }
}