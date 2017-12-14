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
using NBT.Core.Domain.Catalog.Dto;

namespace NBT.Infra.Services.Catalog
{
    public class TourService : ServiceBase<Tour>, ITourService
    {
        ITourRepository _tourRepo;
        ITourAttributeRepository _tourAttributeRepository;
        ITourAttributeValueRepository _tourAttributeValueRepository;
        public TourService(IUnitOfWork unitOfWork
            , ITourRepository tourRepo
            , ITourAttributeValueRepository tourAttributeValueRepository
            , ITourAttributeRepository tourAttributeRepository) : base(unitOfWork, tourRepo)
        {
            _tourRepo = tourRepo;
            _tourAttributeRepository = tourAttributeRepository;
            _tourAttributeValueRepository = tourAttributeValueRepository;
        }
        public TourDto GetById(long id)
        {
            var query = (from t in _tourRepo.TableNoTracking.Where(x => x.Id == id)
                         select new TourDto
                         {
                             Id = t.Id,
                             Alias = t.Alias,
                             Code = t.Code,
                             CountryRegionId = t.CountryRegionId,
                             CreatedBy = t.CreatedBy,
                             CreatedDate = t.CreatedDate,
                             DescriptionSeo = t.DescriptionSeo,
                             FromDate = t.FromDate,
                             FullDescription = t.FullDescription,
                             Image = t.Image,
                             IsDel = t.IsDel,
                             IsShow = t.IsShow,
                             KeywordSeo = t.KeywordSeo,
                             Name = t.Name,
                             ShortDescription = t.ShortDescription,
                             StateProvinceId = t.StateProvinceId,
                             TitleSeo = t.TitleSeo,
                             ToDate = t.ToDate,
                             UpdatedBy = t.UpdatedBy,
                             UpdatedDate = t.UpdatedDate,
                             Price = t.Price
                         }).FirstOrDefault();
            var modelAttr = _tourAttributeValueRepository.TableNoTracking.Where(x => x.TourId == id).ToList();
            query.TourAttr = modelAttr;
            return query;
        }
        public IPagedList<Tour> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", int stateProvinceId = 0, int countryRegionId = 0)
        {
            var query = _tourRepo.TableNoTracking;

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter) || x.Code.Contains(filter));
            if (stateProvinceId != 0)
                query = query.Where(x => x.StateProvinceId == stateProvinceId);
            if (countryRegionId != 0)
                query = query.Where(x => x.CountryRegionId == countryRegionId);

            return query.OrderByDescending(x => x.CreatedDate).ThenByDescending(x => x.Name).ToPagedList(pageIndex, pageSize);
        }


    }
}
