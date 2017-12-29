using NBT.Core.Services.ApplicationServices.System;
using NBT.Web.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class ContactController : BaseController
    {
        IConverseService _converseService;
        public ContactController(IConverseService converseService)
        {
            _converseService = converseService;
        }

        public ActionResult Index()
        {
            this.LoadDefaultMetaSEO();
            var model = _converseService.GetAll(true);
            ViewBag.WebSettings = this.WebSetting;
            return View(model);
        }
    }
}