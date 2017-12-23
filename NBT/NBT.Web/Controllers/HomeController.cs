using NBT.Core.Services.ApplicationServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class HomeController : Controller
    {
        ITourService _tourService;
        public HomeController(ITourService tourService)
        {
            _tourService = tourService;
        }
        public ActionResult Index()
        {
            var model = _tourService.GetHomeTop(10);
            return View(model);
        }

    }
}