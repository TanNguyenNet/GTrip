using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.Immigrant;
using NBT.Core.Services.ApplicationServices.System;

namespace NBT.Web.Api.Controllers.Immigrant
{
    [RoutePrefix("api/visas")]
    [Authorize]
    public class VisaController : BaseApiController
    {
        IVisaService _visaService;
        public VisaController(IErrorService errorService
            , IVisaService visaService) : base(errorService)
        {
            _visaService = visaService;
        }
    }
}
