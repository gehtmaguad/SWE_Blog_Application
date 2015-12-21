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
            ID = mdl.ID;
            BirtDate = mdl.BirtDate;
            EMail = mdl.EMail;
            FirstName = mdl.FirstName;
            Group = mdl.Group;
            LastName = mdl.LastName;
            MiddleName = mdl.MiddleName;
            NeedPasswordReset = mdl.NeedPasswordReset;
            ValidationToken = mdl.ValidationToken;
            IsDeleted = mdl.IsDeleted;
        }

        public DateTime? BirtDate
        {
            get;
            set;
        }

        public string ChangePassword
        {
            get;
            set;
        }

        public string ChangePasswordRepeat
        {
            get;
            set;
        }

        public string DisplayName
        {
            get {
                return ((FirstName.Trim() + " " + MiddleName.Trim()).Trim() + " " + LastName.Trim()).Trim();;
            }
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
            // TODO: Complete getter and setter
            //get
            //{
            //    throw new NotImplementedException();
            //}
            //set
            //{
            //    throw new NotImplementedException();
            //}
            get;
            set;
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> Groups
        {
            // TODO: Complete getter and remove setter
            //get
            //{
            //    throw new NotImplementedException();
            //}
            get;
            set;
        }

        public int ID
        {
            get;
            private set;
        }

        public bool IsDeleted
        {
            get;
            private set;
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

        public Guid ValidationToken
        {
            get;
            private set;
        }
    }
}