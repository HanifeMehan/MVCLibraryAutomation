using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categoryDal = categorydal;
        }


        public void CategoryAdd(Category category)
        {

            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);//Silme işlemi gerçekleştirildi.
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);//id den gelen değere eşit olup olmadığını sorgularız.
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

      /*  public void CategoryAddBL(Category p)
        {
            if(p.CategoryName =="" || p.CategoryStatus == false || p.CategoryName.Length <= 2)
            {
                //hata mesajı
            }
            else
            {
                _categorydal.Insert(p);
            }
        }
      */

    }
    
}
