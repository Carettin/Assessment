using Assessment.Entity;
using Assessment.Models;
using System.Collections.Generic;

namespace Assessment.Services
{
    public interface IInfoService 
    {
        Info GetById(int infoid);
        IList<Info> Getinfos();
        void CreateInfo(Info info);
        void UpdateInfo(Info info);
        void DeleteInfo(int infoid);
        void CreateInfo(InfoModel info);
    }
}
