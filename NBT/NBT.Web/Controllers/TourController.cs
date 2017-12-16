using AutoMapper;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Web.Framework.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class TourController : Controller
    {
        IContinentService _continentService;
        ICountryRegionService _countryRegionService;
        IStateProvinceService _stateProvinceService;
        public TourController(
            IContinentService continentService,
            ICountryRegionService countryRegionService,
            IStateProvinceService stateProvinceService
            )
        {
            _continentService = continentService;
            _countryRegionService = countryRegionService;
            _stateProvinceService = stateProvinceService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ForeignCategory()
        {
            MenuGeographyVm model = new MenuGeographyVm();
            var modelContinent = _continentService.GetAll();
            var modelCountryRegion = _countryRegionService.GetAll(true).ToList();
            var modelStateProvince = _stateProvinceService.GetAll(true);
            model.Continents = Mapper.Map<List<ContinentVm>>(modelContinent);
            model.CountryRegions = Mapper.Map<List<CountryRegionVm>>(modelCountryRegion);
            model.StateProvinces = Mapper.Map<List<StateProvinceVm>>(modelStateProvince);
            return PartialView(model);
        }
    }
}