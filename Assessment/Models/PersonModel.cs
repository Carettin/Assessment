using Assessment.Entity;
using System.Collections.Generic;

namespace Assessment.Models
{
    public class PersonTableListModel
    {
        public PersonTableListModel()
        {
            this.Bilgiler = new List<Info>();
        }

        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public IList<Info> Bilgiler { get; set; }

    }

    public class PersonWithLocationModel
    {
        public PersonWithLocationModel()
        {
            this.PersonTableListModels = new List<PersonTableListModel>();
            this.PersonForLocationReportModels = new List<PersonForLocationReportModel>();
        }
        public List<PersonTableListModel> PersonTableListModels { get; set; }
        public IList<PersonForLocationReportModel> PersonForLocationReportModels { get; set; }
    }



    public class PersonAddOrUpdateModel
    {
        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public Info Bilgiler { get; set; }
    }

}
