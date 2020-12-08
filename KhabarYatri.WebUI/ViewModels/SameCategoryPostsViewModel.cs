using KhabarYatri.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhabarYatri.WebUI.ViewModels
{
    public class SameCategoryPostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public string Category { get; set; }
    }
}