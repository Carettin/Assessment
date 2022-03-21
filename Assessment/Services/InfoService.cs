using Assessment.Data;
using Assessment.Entity;
using Assessment.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Services
{
    public class InfoService : IInfoService
    {

        private DbAssessmentContext _context;
        private ICacheService _cacheService;
        public InfoService(DbAssessmentContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public void CreateInfo(Info info)
        {
            _context.Infos.Add(info);
            _context.SaveChanges();
            _cacheService.Remove("Infos");
        }

        public void CreateInfo(InfoModel info)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteInfo(int infoid)
        {
            var info = GetById(infoid);

            if (info != null)
            {
                _context.Infos.Remove(info);
                _context.SaveChanges();

                _cacheService.Remove("Infos");
            }
        }

        public Info GetById(int infoid)
        {
            return _context.Infos.FirstOrDefault(i => i.Id == infoid);
        }

        public IList<Info> Getinfos()
        {
            if (_cacheService.Any("Infos"))
            {
                var infoCaches = _cacheService.Get<List<Info>>("Infos");
                return infoCaches;
            }
            var infos = _context.Infos.ToList();
            _cacheService.Add("Infos", infos);

            return infos;
        }

        public void UpdateInfo(Info info)
        {
            _context.Infos.Update(info);
            _context.SaveChanges();
            _cacheService.Remove("Infos");
            _cacheService.Remove("Persons");
        }
    }
}
