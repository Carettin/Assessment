using Assessment.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Services
{
    public interface IPersonService
    {
        Person GetById(int personid);
        IList<Person> GetPersons();
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int personid);

    }
}
