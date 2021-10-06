using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAdd(Heading heading);
        Heading GetByID(int id);//Dışarıdan id değişkeni alır.Ona göre işlem yapar.
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}
