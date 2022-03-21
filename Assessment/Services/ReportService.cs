using Assessment.Data;
using Assessment.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Services
{
    public class ReportService : IReportService
    {

        private DbAssessmentContext _context;
        private ICacheService _cacheService;
        public ReportService(DbAssessmentContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public List<PersonForLocationReportModel> GetLocationByCount()
        {
            List<PersonForLocationReportModel> currentLocationCount = new List<PersonForLocationReportModel>();


            if (_cacheService.Any("GetLocationByCounts"))
            {
                var currentLocationCountCaches = _cacheService.Get<List<PersonForLocationReportModel>>("GetLocationByCounts");
                return currentLocationCountCaches;
            }

            var infosForLocations = _context.Infos.ToList();

            var infosGrouped = infosForLocations.GroupBy(m => new { Location = m.Location });
            

            foreach (var item in infosGrouped)
            {
                currentLocationCount.Add(new PersonForLocationReportModel
                {
                    Location = item.Key.Location,
                    LocationCount = infosForLocations.Count(m => m.Location == item.Key.Location),
                    PhoneCount = infosForLocations.Count(m => m.Location == item.Key.Location)
                });
            }

            _cacheService.Add("GetLocationByCounts", currentLocationCount);


           /* var infosGrouped2 = infosForLocations.GroupBy(m => m.Phone);

            foreach (var item in infosGrouped2)
            {
                currentLocationCount.Add(new PersonForLocationReportModel
                { PhoneIdCount = infosForLocations.Count(m => m.Phone == item.Key) });
            }*/


            //_cacheService.Add("GetLocationByCounts", currentLocationCount);



            return currentLocationCount;
        }

        //public List<PersonForLocationReportModel> GetPersonIdbyCount()
        //{
        //    List<PersonForLocationReportModel> currentphoneidcount = new List<PersonForLocationReportModel>();


        //    if (_cacheService.Any("GetPhoneIdByCounts"))
        //    {
        //        var currentPhoneIdCountCaches = _cacheService.Get<List<PersonForLocationReportModel>>("GetPhoneIdByCounts");
        //        return currentPhoneIdCountCaches;
        //    }

        //    var infosForPhones = _context.Infos.ToList();

        //    var infosGrouped2 = infosForPhones.GroupBy(m => m.Phone);


        //    foreach (var item in infosGrouped2)
        //    {
        //        currentphoneidcount.Add(new PersonForLocationReportModel { PhoneIdCount = infosForPhones.Count(m => m.Phone == item.Key) });
        //    }

        //    _cacheService.Add("GetPhoneIdByCounts", currentphoneidcount);

        //    return currentphoneidcount;
        //}
    }
}
