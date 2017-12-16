using AutoMapper;
using NBT.Core.Domain.Catalog;
using NBT.Core.Domain.Catalog.Dto;
using NBT.Core.Domain.Identity;
using NBT.Web.Framework.Models.Catalog;
using NBT.Web.Framework.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AppUser, AppUserVm>();
                cfg.CreateMap<AppGroup, AppGroupVm>();
                cfg.CreateMap<TourDto, Tour>();
                cfg.CreateMap<Continent, ContinentVm>();
                cfg.CreateMap<CountryRegion, CountryRegionVm>();
                cfg.CreateMap<StateProvince, StateProvinceVm>();
            });
        }
    }
}