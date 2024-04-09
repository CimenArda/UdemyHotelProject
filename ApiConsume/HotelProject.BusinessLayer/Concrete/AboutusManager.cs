using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutusManager : IAboutusService
    {
        private readonly IAboutusDal _aboutusdal;

        public AboutusManager(IAboutusDal aboutusdal)
        {
            _aboutusdal = aboutusdal;
        }

        public void TDelete(AboutUs t)
        {
            _aboutusdal.Delete(t);
        }

        public AboutUs TGetbyId(int id)
        {
            return _aboutusdal.GetbyId(id);
        }

        public List<AboutUs> TGetList()
        {
            return _aboutusdal.GetList();
        }

        public void TInsert(AboutUs t)
        {
           _aboutusdal.Insert(t);
        }

        public void TUpdate(AboutUs t)
        {
           _aboutusdal.Update(t);
        }
    }
}
