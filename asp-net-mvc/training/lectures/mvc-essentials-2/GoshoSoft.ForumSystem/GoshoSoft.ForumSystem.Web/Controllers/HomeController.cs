using AutoMapper;
using AutoMapper.QueryableExtensions;
using GoshoSoft.ForumSystem.Models;
using GoshoSoft.ForumSystem.Services;
using GoshoSoft.ForumSystem.Web.Infrastructure;
using GoshoSoft.ForumSystem.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace GoshoSoft.ForumSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IMapper mapper;

        public HomeController(IPostsService postsService, IMapper mapper)
        {
            this.postsService = postsService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var newPost = new Post()
            {
                Title = "awesome title",
                Content = "veryawesome content"
            };

            this.postsService.AddPost(newPost);

            var posts = this.postsService.GetAll()
                .ProjectTo<PostViewModel>()
                .ToList();

            var viewModel = new HomeViewModel
            {
                Posts = posts
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(PostViewModel model)
        {
            return this.RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetPosts()
        {
            //returns html
            //Thread.Sleep(2000);
            //var posts = this.postsService.GetAll()
            //    .ProjectTo<PostViewModel>()
            //    .ToList();

            //return this.PartialView("_PostsListTitle", posts);

            //returns json
            if (this.Request.IsAjaxRequest())
            {
                var posts = this.postsService.GetAll()
                    .ProjectTo<PostViewModel>()
                    .ToList();

                return this.Json(posts, JsonRequestBehavior.AllowGet);
            }

            return this.Content("No data for you");
        }
    }
}