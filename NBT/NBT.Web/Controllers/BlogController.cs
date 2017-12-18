using NBT.Core.Domain.Blog;
using NBT.Core.Services.ApplicationServices.Blog;
using NBT.Web.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class BlogController : Controller
    {
        IBlogPostService _blogPostService;
        public BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        // GET: Blog
        public ActionResult Index(int pageIndex = 1, int pageSize = 12, string filter = "")
        {
            var model = _blogPostService.GetAll(pageIndex = 1, pageSize = 12, filter = "", true);
            PaginationSet<BlogPost> pagedSet = new PaginationSet<BlogPost>()
            {
                Page = pageIndex,
                TotalCount = model.TotalItemCount,
                TotalPages = (int)Math.Ceiling((decimal)model.TotalItemCount / pageSize),
                Items = model
            };
            return View(pagedSet);
        }

        public ActionResult Detail(string alias)
        {
            var model = _blogPostService.GetByAlias(alias);
            return View(model);
        }
    }
}