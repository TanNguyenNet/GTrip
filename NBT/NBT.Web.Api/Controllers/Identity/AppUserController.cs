using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Infra.Services.Identity;
using NBT.Core.Services.ApplicationServices.Security;

namespace NBT.Web.Api.Controllers.Identity
{
    public class AppUserController : BaseApiController
    {
        ApplicationUserManager _userManager;
        IAppGroupService _appGroupService;
        IAppRoleService _appRoleService;
        IAppUserService _appUserService;
        public AppUserController(IErrorService errorService) : base(errorService)
        {
        }
    }
}
