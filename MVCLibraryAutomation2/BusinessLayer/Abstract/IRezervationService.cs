using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRezervationService
    {
        List<Rezervation> GetList();
        void RezervationAdd(Rezervation rezervation);
        Rezervation GetByID(int id);//Dışarıdan id değişkeni alır.Ona göre işlem yapar.
        void RezervationDelete(Rezervation rezervation);
        void RezervationUpdate(Rezervation rezervation);
    }
}
