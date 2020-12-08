using KhabarYatri.Base.Entities;
using KhabarYatri.SQL;
using KhabarYatri.WebUI.Models;
using KhabarYatri.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhabarYatri.WebUI.Controllers
{
    //[Authorize]
    public class PostManagerController : Controller
    {
        DataContext context;
        Post post = new Post();
        public PostManagerController()
        {
            context = new DataContext();
        }
        // GET: Post
        public ActionResult Index()
        {
            var commentModel = new PostCommentViewModel
            {
                Posts = from post in context.Posts
                        orderby post.PostId descending
                        select post,
                Comments = context.Comments.Include(c => c.Post)
            };
            return View(commentModel);
        }

        public ActionResult Create()
        {
            var model = new PostViewModel
            {
                Post = new Post(),
                Categories = context.Categories
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Post post,HttpPostedFileBase file)
        {
            if(!ModelState.IsValid)
                return View(post);
            if (file != null)
            {
                //Saving Image file to the device
                post.Image = Guid.NewGuid().ToString() +"-"+ Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("//Content//Images//") + post.Image);
                
            }
            context.Posts.Add(post);
            context.SaveChanges();
            return RedirectToAction("Home","khabaryatri");
        }

        


    }
}