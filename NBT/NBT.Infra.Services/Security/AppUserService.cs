using NBT.Core.Domain.Identity;
using NBT.Core.Services.ApplicationServices.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Security;

namespace NBT.Infra.Services.Security
{
    public class AppUserService : ServiceBase<AppUser>, IAppUserService
    {
        IAppUserRepository _appUserRepo;
        public AppUserService(IUnitOfWork unitOfWork, IAppUserRepository appUserRepo) : base(unitOfWork, appUserRepo)
        {
            _appUserRepo = appUserRepo;
        }
    }
}
