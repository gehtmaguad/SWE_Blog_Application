using MSE.SWE.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            PasswordHash = mdl.PasswordHash;
            ValidationToken = mdl.ValidationToken;
            IsDeleted = mdl.IsDeleted;
        }

        public int ID { get; private set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? BirtDate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public UserGroup Group { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool NeedPasswordReset { get; set; }
        public string PasswordHash { get; set; }
        public Guid ValidationToken { get; private set; }
        public bool IsDeleted { get; private set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Groups
        {
            get
            {
                return new[] 
                {
                    new SelectListItem
                    {
                        Text = UserGroup.User.ToString(),
                        Value = UserGroup.User.ToString()
                    },
                    new SelectListItem
                    {
                        Text = UserGroup.Admin.ToString(),
                        Value = UserGroup.Admin.ToString()
                    },
                };
            }
        }
        public string ChangePassword { get; set; }
        public string ChangePasswordRepeat { get; set; }
        public string DisplayName
        {
            get {
                return ConcatenateString(ConcatenateString(FirstName, MiddleName),LastName);
            }
        }

        private string ConcatenateString(string first, string second)
        {
            if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
            {
                return (first.Trim() + " " + second.Trim()).Trim();
            } else if (!string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second))
            {
                return first.Trim();
            } else if (string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
            {
                return second.Trim();
            } else
            {
                return string.Empty;
            }
        }

        public void ApplyChanges(IUser obj)
        {
            obj.BirtDate = BirtDate;
            obj.EMail = EMail;
            obj.FirstName = FirstName;
            obj.Group = Group;
            obj.LastName = LastName;
            obj.MiddleName = MiddleName;
            obj.NeedPasswordReset = NeedPasswordReset;
            obj.PasswordHash = PasswordHash;
            obj.ValidationToken = ValidationToken;
            obj.IsDeleted = IsDeleted;
        }
    }
}