using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.ApplicationServices.Security;
using NBT.Web.Framework.Models.Security;
using AutoMapper;
using NBT.Core.Domain.Identity;
using NBT.Web.Framework.Core;
using System.Threading.Tasks;

namespace NBT.Web.Api.Controllers.Identity
{
    [RoutePrefix("api/appRole")]
    //[Authorize]
    public class AppRoleController : BaseApiController
    {
        IAppRoleService _appRoleService;
        public AppRoleController(IErrorService errorService
            , IAppRoleService appRoleService) : base(errorService)
        {
            _appRoleService = appRoleService;
        }

        [Route("getlistpaging")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewPermission))]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                _appRoleService.InsertRoleFromSystem();
                int totalRow = 0;
                var model = _appRoleService.GetAll(page, pageSize, out totalRow, filter);
                IEnumerable<AppRoleVm> modelVm = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRoleVm>>(model);

                PaginationSet<AppRoleVm> pagedSet = new PaginationSet<AppRoleVm>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}
