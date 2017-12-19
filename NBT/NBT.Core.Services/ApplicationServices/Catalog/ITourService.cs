using NBT.Core.Domain.Catalog;
using NBT.Core.Domain.Catalog.Dto;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Catalog
{
    public interface ITourService : IService<Tour>
    {
        TourDto GetById(long id);
        TourDto GetByAlias(string alias);
        IPagedList<Tour> GetAll(int pageIndex =1, int pageSize=20, string filter ="", int stateProvinceId=0, int countryRegionId=0);
        IPagedList<TourDto> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", int stateProvinceId = 0, int countryRegionId = 0,bool? isShow=null);
        void DeleteById(long id);

    }
}
