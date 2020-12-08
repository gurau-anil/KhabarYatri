using KhabarYatri.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhabarYatri.WebUI.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}