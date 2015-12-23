using MSE.SWE.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyMSEBlog.Core.DAL
{
    public class FileDAL : IDAL
    {
        private string _fileName;

        public FileDAL(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException("fileName");
            _fileName = fileName;
        }

        FileRepository _repo = null;
        private void Load()
        {
            if (_repo == null)
            {
                if (File.Exists(_fileName))
                {
                    using (var fs = new FileStream(_fileName, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(FileRepository));
                        _repo = (FileRepository)serializer.Deserialize(fs);
                    }
                }
                else
                {
                    _repo = new FileRepository();
                }

                EnsureDefaultData();

                // Ensure valid internal state
                foreach (BlogPost post in _repo.Posts)
                {
                    post.Repo = _repo;
                }
            }
        }

        private void EnsureDefaultData()
        {
            var defaultDataWasInitialized = false;
            if (_repo.Users == null || _repo.Users.Count == 0)
            {
                _repo.Users = new List<User>() { new User() { ID = 1, LastName = "Administrator", EMail = "test@test.com", PasswordHash = "1234", Group = MSE.SWE.Interfaces.UserGroup.Admin } };
                defaultDataWasInitialized = true;
            }
            if (_repo.Posts == null || _repo.Posts.Count == 0)
            {
                _repo.Posts = new List<BlogPost>() { new BlogPost() { ID = 1, Title = "Hello Blog!", Content = "Hello!", CreatedOn = DateTime.Now, CreatedBy = _repo.Users.First() } };
                defaultDataWasInitialized = true;
            }
            if (defaultDataWasInitialized)
            {
                SaveChanges();
            }
        }

        public void AddPost(IBlogPost post)
        {
            Load();
            var obj = (BlogPost)post;
            obj.ID = _repo.Posts.Max(i => i.ID) + 1;
            _repo.Posts.Add(obj);
        }

        public void AddUser(IUser user)
        {
            Load();
            var obj = (User)user;
            obj.ID = _repo.Users.Max(i => i.ID) + 1;
            _repo.Users.Add(obj);
        }

        public void DeletePost(IBlogPost post)
        {
            Load();
            var obj = (BlogPost)post;
            _repo.Posts.Single(i => i.ID.Equals(obj.ID)).IsDeleted = true;
        }

        public void DeleteUser(IUser user)
        {
            Load();
            var obj = (User)user;
            _repo.Users.Single(i => i.ID.Equals(obj.ID)).IsDeleted = true;
        }

        public IQueryable<IBlogPost> GetPostList()
        {
            Load();
            return _repo.Posts.AsQueryable<IBlogPost>();
        }

        public IQueryable<IUser> GetUserList()
        {
            Load();
            return _repo.Users.AsQueryable<IUser>();
        }

        public void SaveChanges()
        {
            if (_repo == null) throw new InvalidOperationException("Unable to save a closed repository");
            var serializer = new XmlSerializer(typeof(FileRepository));
            using (var fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                serializer.Serialize(fs, _repo);
            }
        }
    }
}
