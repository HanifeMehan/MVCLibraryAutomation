using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibraryAutomation2.Controllers
{
    public class AdminCategoryController : Controller
    {
        //Daha az bağımlılık yaratmak kullanıyoruz.
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        [Authorize]//Index sayfamızı artık giriş yapan kişiler görebiliriz.(B)ile sadece B rolüne sahip kişlerin görüntüleyebilmesi sağlanabilir.
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //Geçerlilik sorgulaması yapılacağı için CategoryValidatior çağırılır.
            CategoryValidator categoryvalidatior = new CategoryValidator();
            ValidationResult results = categoryvalidatior.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                //Index Action a yönlendirildi
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);

                }

            }
            return View();

        }
        public ActionResult DeleteCategory(int id)//artık sil butonuna tıkladığımızda id yi alıyoruz.
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);//gönderilen id deki veriler silinir.
            return RedirectToAction("Index");
        }

        [HttpGet]//Sayfa Yüklemdiği zaman çalışmasını istiyoruz
        public ActionResult EditCategory(int id)
        {
            //öncelikle güncellenilecek olan category bulunmalı.
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}