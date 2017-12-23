using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Header(string style)
        {
            ViewBag.StyleHeader = style;
            return PartialView(this.webSettingsVm);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            
            return PartialView(this.webSettingsVm);
        }

        [ChildActionOnly]
        public ActionResult Navigation()
        {
            return PartialView();
        }
    }
}