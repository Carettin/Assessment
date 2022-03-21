using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Assessment.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assessment.Services;

namespace Assessment.Controllers
{
    public class HomeController : Controller
    {
        private IPersonService _personService;
        private IReportService _reportService;
        private IInfoService _infoService;

        public HomeController(IPersonService personService, IReportService reportService, IInfoService infoService)
        {
            _personService = personService;
            _reportService = reportService;
            _infoService = infoService;
        }

        public IActionResult Index() 
        {

            PersonWithLocationModel  personWithLocationModel = new PersonWithLocationModel();

            var personModel = _personService.GetPersons().Select(m => new PersonTableListModel
            {
                UUID = m.UUID,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Company = m.Company,
                Bilgiler = m.Bilgiler.ToList()
        });

            personWithLocationModel.PersonTableListModels.AddRange(personModel);
            personWithLocationModel.PersonForLocationReportModels = _reportService.GetLocationByCount();

            return View(personWithLocationModel);
        }


        public IActionResult Update(int Id)
        {
            var currentPerson = _personService.GetById(Id);

            var currentPersonModel = new PersonAddOrUpdateModel
            { 
                UUID = currentPerson.UUID,
                FirstName = currentPerson.FirstName,
                LastName = currentPerson.LastName,
                Company = currentPerson.Company
            };

            return View(currentPersonModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PersonAddOrUpdateModel person)
        {

            Info info = new Info();
            Person _person = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Company = person.Company, 
                CreateDatetime = DateTime.Now, 
                IpAdres = "createLocal" };


            if (person.Bilgiler != null)
            {
                _person.Bilgiler = new List<Info>();

                info = new Info
                {
                    Email = person.Bilgiler.Email,
                    Phone = person.Bilgiler.Phone,
                    Location = person.Bilgiler.Location                  
                };
                _person.Bilgiler.Add(info);
            }

            _personService.CreatePerson(_person);


            /*
            if (info.PersonId>0)
            {
                _infoService.CreateInfo(info);
            }
            */





            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Update(PersonAddOrUpdateModel person)
        {
            var currentPerson = _personService.GetById(person.UUID);

            currentPerson.UpdateDatetime = DateTime.Now;
            currentPerson.Company = person.Company;
            currentPerson.IpAdres = "local";
            currentPerson.FirstName = person.FirstName;
            currentPerson.LastName = person.LastName;

            _personService.UpdatePerson(currentPerson);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _personService.DeletePerson(id);
            TempData["Message"] ="{id} kişisi silindi.";
            return RedirectToAction("Index");
        }

    }

}
 