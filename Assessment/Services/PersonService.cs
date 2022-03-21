using Assessment.Data;
using Assessment.Entity;
using Assessment.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Services
{
    public class PersonService : IPersonService
    {
        private DbAssessmentContext _context;
        private ICacheService _cacheService;

        
        public PersonService(DbAssessmentContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
            

        }

        public IList<Person> GetPersons()
        {

            
           if (_cacheService.Any("Persons"))
           {
               var personCaches = _cacheService.Get<List<Person>>("Persons");
                return personCaches;
           }
            var persons = _context.Persons.Include(m => m.Bilgiler).ToList();
           _cacheService.Add("Persons", persons);

            return persons;
        }

        public void CreatePerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            _cacheService.Remove("Persons");

        }

        public void DeletePerson(int personid)
        {
            var person = GetById(personid);

            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();

                _cacheService.Remove("Persons");
            }
        }

        public Person GetById(int personid)
        {

            return _context.Persons.Include(m=>m.Bilgiler).FirstOrDefault(i => i.UUID == personid);
        }

        public void UpdatePerson(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
            _cacheService.Remove("Persons");
        }
    }
}
