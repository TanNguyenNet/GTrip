using AutoMapper;
using NBT.Core.Domain.Identity;
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
            });
        }
    }
}