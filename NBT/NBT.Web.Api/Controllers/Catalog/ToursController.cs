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
using NBT.Core.Domain.Catalog.Dto;
using AutoMapper;
using Microsoft.AspNet.Identity;
using NBT.Core.Services.Data;
using NBT.Core.Common.Helper;

namespace NBT.Web.Api.Controllers.Catalog
{
    [RoutePrefix("api/tours")]
    [Authorize]
    public class ToursController : BaseApiController
    {
        ITourService _tourService;
        ITourAttributeValueService _tourAttributeValueService;
        IUnitOfWork _uow;
        public ToursController(IErrorService errorService
            , ITourService tourService
            , ITourAttributeValueService tourAttributeValueService
            , IUnitOfWork uow) : base(errorService)
        {
            _tourService = tourService;
            _tourAttributeValueService = tourAttributeValueService;
            _uow = uow;
        }

        [Route("getAll")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewProduct))]
        public HttpResponseMessage getAll(HttpRequestMessage request,
            int page = 0, int pageSize = 20, string filter = "", int stateProvinceId = 0, int countryRegionId = 0)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _tourService.GetAll(page + 1, pageSize, filter, stateProvinceId, countryRegionId);
                PaginationSet<Tour> pagedSet = new PaginationSet<Tour>()
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

        [Route("getByid/{id:int}")]
        [HttpGet]
        //[Authorize(Roles = nameof(PermissionProvider.ViewGroup))]
        public HttpResponseMessage GetByid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _tourService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Create(HttpRequestMessage request, TourDto tourDto)
        {
            return CreateHttpResponse(request, () =>
            {

                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var modelTour = Mapper.Map<Tour>(tourDto);
                    modelTour.Alias = StringHelper.ToUrlFriendlyWithDateTime(modelTour.Name);
                    modelTour.FromDate = modelTour.FromDate.UtcDateTime;
                    modelTour.ToDate = modelTour.ToDate.UtcDateTime;
                    modelTour.CreatedDate = GetDateTimeNowUTC();
                    modelTour.CreatedBy = User.Identity.GetUserId();
                    _uow.BeginTran();
                    _tourService.Add(modelTour);

                    if (tourDto.TourAttr.Count > 0)
                        foreach (var item in tourDto.TourAttr)
                        {
                            item.TourId = modelTour.Id;
                        }
                    _tourAttributeValueService.Add(tourDto.TourAttr);

                    _uow.CommitTran();

                    reponse = request.CreateResponse(HttpStatusCode.Created, modelTour);
                }
                return reponse;

            });
        }

        [Route("update")]
        [HttpPut]
        //[Authorize(Roles = nameof(PermissionProvider.AddArea))]
        public HttpResponseMessage Update(HttpRequestMessage request, TourDto tourDto)
        {
            return CreateHttpResponse(request, () =>
            {

                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var modelTour = Mapper.Map<Tour>(tourDto);
                    modelTour.FromDate = modelTour.FromDate.UtcDateTime;
                    modelTour.ToDate = modelTour.ToDate.UtcDateTime;
                    modelTour.UpdatedDate = GetDateTimeNowUTC();
                    modelTour.UpdatedBy = User.Identity.GetUserId();
                    if (tourDto.TourAttr.Count > 0)
                        foreach (var item in tourDto.TourAttr)
                        {
                            item.TourId = modelTour.Id;
                        }
                    _uow.BeginTran();
                    _tourService.Update(modelTour);
                    _tourAttributeValueService.DeleteByTourId(modelTour.Id);
                    _tourAttributeValueService.Add(tourDto.TourAttr);
                    _uow.CommitTran();

                    reponse = request.CreateResponse(HttpStatusCode.Created, modelTour);
                }
                return reponse;

            });
        }

    }
}
