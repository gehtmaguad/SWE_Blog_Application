using MSE.SWE.Interfaces;
using System;
using System.Collections.Generic;
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
            Content = mdl.Content;
            CreatedBy = new UserViewModel(mdl.CreatedBy);
            CreatedOn = mdl.CreatedOn;
            ID = mdl.ID;
            IsDeleted = mdl.IsDeleted;
            Summary = mdl.Summary;
            Tags = mdl.Tags;
            Title = mdl.Title;
        }

        public string Content { get; set; }
        public IUserViewModel CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string DisplayText
        {
            get
            {
                return Content;
            }
        }
        public int ID { get; private set; }
        public bool IsDeleted { get; private set; }
        public string Summary { get; set; }
        public string Tags { get; set; }
        public string Title { get; set; }

    }
}
