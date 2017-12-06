using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.ApplicationServices.Security;

namespace NBT.Web.Api.Controllers.Identity
{
    [RoutePrefix("api/appGroup")]
    [Authorize]
    public class AppGroupController : BaseApiController
    {
        IAppGroupService _appGroupService;
        IAppRoleService _appRoleService;
        public AppGroupController(IErrorService errorService,
            IAppGroupService appGroupService,
            IAppRoleService appRoleService) : base(errorService)
        {
            _appGroupService = appGroupService;
            _appRoleService = appRoleService;
        }
    }
}
