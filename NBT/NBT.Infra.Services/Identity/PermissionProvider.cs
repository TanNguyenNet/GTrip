using NBT.Core.Services.DomainServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Domain.Identity;

namespace NBT.Infra.Services.Identity
{
    public class PermissionProvider : IPermissionProvider
    {
        public static readonly string ViewPermission;

        public static readonly AppRole ViewPermissionRecord = new AppRole { Name = nameof(ViewPermission), Description = "Xem quyền" };
        public IEnumerable<AppRole> GetPermissions()
        {
            return new[]
            {
                ViewPermissionRecord
            };
        }
    }
}
