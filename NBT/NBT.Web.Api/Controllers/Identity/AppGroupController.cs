using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;

namespace NBT.Web.Api.Controllers.Identity
{
    public class AppGroupController : BaseApiController
    {

        public AppGroupController(IErrorService errorService) : base(errorService)
        {

        }
    }
}
