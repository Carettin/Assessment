using Assessment.Entity;
using Assessment.Models;
using Assessment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class InfoController : Controller
    {
        private IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public IActionResult Update(int Id)
        {
            var currentPerson = _infoService.GetById(Id) == null ? new Info() : _infoService.GetById(Id);

            var currentPersonModel = new InfoModel
            {
                Id = currentPerson.Id,
                Location = currentPerson.Location,
                Email = currentPerson.Email,
                Phone = currentPerson.Phone
            };

            return View(currentPersonModel);
        }

        [HttpPost]
        public IActionResult Update(InfoModel person)
        {
            var currentPerson = _infoService.GetById(person.Id) ==null ? new Info() : _infoService.GetById(person.Id);

            currentPerson.Location = person.Location;
            currentPerson.Email = person.Email;
            currentPerson.Phone = person.Phone;
            currentPerson.PersonId = person.PersonId;
            _infoService.UpdateInfo(currentPerson);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create(int PersonId)
        {
            InfoModel _info = new InfoModel();
            _info.PersonId = PersonId;
            return View(_info);
        }
        [HttpPost]
        public IActionResult Create(InfoModel info)
        {

            InfoModel _info = new InfoModel
            {
                Phone = info.Phone,
                Email = info.Email,
                Location = info.Location,
            };

            _infoService.CreateInfo(_info);
            return RedirectToAction("Index", "Home");
        }



    }
}
