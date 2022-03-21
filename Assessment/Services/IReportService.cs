using Assessment.Models;
using System.Collections.Generic;

namespace Assessment.Services
{
    public interface IReportService
    {
        List<PersonForLocationReportModel> GetLocationByCount();
        
    }
}
