using NBT.Core.Domain.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Catalog;
using PagedList;
using System.Data.Entity;

namespace NBT.Infra.Services.Catalog
{
    public class ContinentService : ServiceBase<Continent>, IContinentService
    {
        IContinentRepository _continentRepo;
        public ContinentService(IUnitOfWork unitOfWork, IContinentRepository continentRepo) : base(unitOfWork, continentRepo)
        {
            _continentRepo = continentRepo;
        }

        public IEnumerable<Continent> GetAll()
        {
            return _continentRepo.TableNoTracking.ToList();
        }
    }
}
