using NBT.Core.Domain.Identity;
using NBT.Web.Framework.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateAppGroup(this AppGroup appGroup, AppGroupVm appGroupViewModel)
        {
            appGroup.Id = appGroupViewModel.Id;
            appGroup.Name = appGroupViewModel.Name;
        }
    }
}