using NBT.Core.Services.ApplicationServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class HomeController : BaseController
    {
        ITourService _tourService;
        public HomeController(ITourService tourService)
        {
            _tourService = tourService;
        }
        public ActionResult Index()
        {
            var model = _tourService.GetHomeTop(10);
            var webSetting = this.WebSetting;
            ViewBag.Title = webSetting.MetaTitle;
            ViewBag.Keyword = webSetting.MetaKeyword;
            ViewBag.Description = webSetting.MetaDescription;
            return View(model);
        }

    }
}