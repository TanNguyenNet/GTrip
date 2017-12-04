using Microsoft.AspNet.Identity;
using NBT.Infra.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        public async Task<ActionResult> Index(ApplicationUserManager userManager)
        {
            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            if (!user.IsSystemAccount)
                return RedirectToAction("Index", "Home");
            return View();
        }
    }
}