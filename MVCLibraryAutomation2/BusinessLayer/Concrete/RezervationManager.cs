using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RezervationManager : IRezervationService
    {
        IRezervationDal _rezervationDal;

        public RezervationManager(IRezervationDal rezervationDal)
        {
            _rezervationDal = rezervationDal;
        }

        public Rezervation GetByID(int id)
        {
            return _rezervationDal.Get(x => x.UserID == id);
        }

        public List<Rezervation> GetList()
        {
            return _rezervationDal.List();
        }

        public void RezervationAdd(Rezervation rezervation)
        {
            _rezervationDal.Insert(rezervation);
        }

        public void RezervationDelete(Rezervation rezervation)
        {
            _rezervationDal.Delete(rezervation);
        }

        public void RezervationUpdate(Rezervation rezervation)
        {
            _rezervationDal.Update(rezervation);
        }
    }
}
