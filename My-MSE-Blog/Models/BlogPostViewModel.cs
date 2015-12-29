using MSE.SWE.Interfaces;
using MyMSEBlog.Core.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMSEBlog.Models
{
    public class BlogPostViewModel : IBlogPostViewModel
    {

        public BlogPostViewModel()
        {
        }

        public BlogPostViewModel(IBlogPost mdl)
        {
            ID = mdl.ID;
            Content = mdl.Content;
            CreatedBy = new UserViewModel(mdl.CreatedBy);
            CreatedOn = mdl.CreatedOn;
            Summary = mdl.Summary;
            Tags = mdl.Tags;
            Title = mdl.Title;
            IsDeleted = mdl.IsDeleted;
        }

        public int ID { get; private set; }
        [Required]
        public string Content { get; set; }
        public IUserViewModel CreatedBy { get; private set; }
        [DataType(DataType.Date)] 
        public DateTime CreatedOn { get; private set; }
        public string Summary { get; set; }
        public string Tags { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDeleted { get; private set; }

        public string DisplayText
        {
            get {
                return ConcatenateString(ConcatenateString(Title, Content), Summary);
            }
        }

        private string ConcatenateString(string first, string second)
        {
            if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
            {
                return (first.Trim() + " " + second.Trim()).Trim();
            }
            else if (!string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second))
            {
                return first.Trim();
            }
            else if (string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
            {
                return second.Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        public void ApplyChanges(IBlogPost obj)
        {
            obj.Content = Content;
            obj.IsDeleted = false;
            obj.Summary = Summary;
            obj.Tags = Tags;
            obj.Title = Title;
            obj.IsDeleted = IsDeleted;
        }
    }
}
