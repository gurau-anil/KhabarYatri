using KhabarYatri.Base.Entities;
using KhabarYatri.SQL;
using KhabarYatri.WebUI.Models;
using KhabarYatri.WebUI.ViewModels;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KhabarYatri.WebUI.Controllers
{
    public class khabaryatriController : Controller
    {
        DataContext context;
        Post post = new Post();
        public khabaryatriController()
        {
            context = new DataContext();
        }
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home(int page=1)
        {
            int PageSize = 5;
            var posts = from post in context.Posts.Include(c => c.Category)
                        orderby post.PostId descending
                        select post;
            var commentModel = new PostCommentViewModel
            {
                Posts = posts.Include(p=>p.Comments).Skip((page - 1) * PageSize).Take(PageSize),
                Comments = context.Comments.OrderByDescending(c=>c.CommentId).Include(c => c.Post),
                RecentPosts=posts.Take(5),
                Comment=new Comment(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = context.Posts.Count()
                }
            };
            return View(commentModel);
        }

        [HttpPost]
        public PartialViewResult Home(Comment comment, int id)
        {

            if (!String.IsNullOrWhiteSpace(comment.Cmnt))
            {
                comment.PostId = id;
                context.Comments.Add(comment);
                context.SaveChanges();
                ModelState.Clear();
                return PartialView("_Comments",comment);
            }
            else
            {
                return PartialView("Error");
            }
        }
        [Route("khabaryatri/post/{id}/{year:regex(\\d{2}):range(1, 20)}")]
        [Route("khabaryatri/post/{id}")]
        public ActionResult PostDetail(int? id)
        {
            var post = context.Posts.FirstOrDefault(p => p.PostId == id);
            var recommendation = context.Posts
                .Where(p => (p.Category.CategoryId == post.CategoryId && (p.PostId != post.PostId)))
                .Take(4)
                .OrderByDescending(p=>p.PostId);
            if(post==null)
            {
                return HttpNotFound();
            }
            else
            {
                var recommendationPosts = new PostAndSameCatRecommendationViewModel
                {
                    Post = post,
                    RecommendPosts = recommendation
                };
                return View(recommendationPosts);
            }
        }

        [Route("khabaryatri/post/category/{category}")]
        public ActionResult PostCategories(string category)
        {
            var posts = context.Posts.Where(cat => cat.Category.Cat == category).OrderByDescending(i=>i.PostId);
            if (posts == null)
            {
                return HttpNotFound();
            }
            var sameCategoryPosts = new SameCategoryPostsViewModel
            {
                Posts=posts,
                Category=category
            };
            
            return View(sameCategoryPosts);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This is a message from god";
            return View();
        }

    }
}