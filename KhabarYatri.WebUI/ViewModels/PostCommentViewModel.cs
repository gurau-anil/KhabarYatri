using KhabarYatri.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhabarYatri.WebUI.ViewModels
{
    public class PostCommentViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Post> RecentPosts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}