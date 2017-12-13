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

namespace NBT.Infra.Services.Catalog
{
    public class StateProvinceService : ServiceBase<StateProvince>, IStateProvinceService
    {
        IStateProvinceRepository _stateProvinceRepo;
        public StateProvinceService(IUnitOfWork unitOfWork, IStateProvinceRepository stateProvinceRepo) : base(unitOfWork, stateProvinceRepo)
        {
            _stateProvinceRepo = stateProvinceRepo;
        }
        public IPagedList<StateProvince> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StateProvince> GetAll()
        {
            return _stateProvinceRepo.TableNoTracking.ToList();
        }
    }
}
