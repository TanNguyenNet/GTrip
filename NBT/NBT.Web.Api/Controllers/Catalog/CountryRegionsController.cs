using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Web.Framework.Core;
using NBT.Core.Domain.Catalog;

namespace NBT.Web.Api.Controllers.Catalog
{
    public class CountryRegionsController : BaseApiController
    {
        ICountryRegionService _countryRegionService;
        public CountryRegionsController(IErrorService errorService
            , ICountryRegionService countryRegionService) : base(errorService)
        {
            _countryRegionService = countryRegionService;
        }

        [Route("GetListPaging")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request,
            int page=0, int pageSize=20, string filter = "", int continentId = 0)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _countryRegionService.GetAll(page + 1, pageSize, filter, continentId);
                PaginationSet<CountryRegion> pagedSet = new PaginationSet<CountryRegion>()
                {
                    Page = page,
                    TotalCount = model.TotalItemCount,
                    TotalPages = (int)Math.Ceiling((decimal)model.TotalItemCount / pageSize),
                    Items = model
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}
