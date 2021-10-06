using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByHeadingID(int id);
        void ContentAdd(Content content);
        Category GetByID(int id);//Dışarıdan id değişkeni alır.Ona göre işlem yapar.
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
