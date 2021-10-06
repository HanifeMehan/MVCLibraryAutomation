using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibraryAutomation2.Controllers
{
    public class RezervationController : Controller
    {
        RezervationManager rm = new RezervationManager(new EFRezervationDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());

        // GET: Rezervation
        public ActionResult Index()
        {
            var rezervationvalues = rm.GetList();
            return View(rezervationvalues);
        }

        [HttpGet]
        public ActionResult AddRezervation()
        {
            List<SelectListItem> valuerezervation = (from x in hm.GetList() select new 
                                                     SelectListItem { Text = x.HeadingName, Value = x.HeadingID.ToString() }).ToList();
            ViewBag.vlc = valuerezervation;
            return View();
        }

        [HttpPost]
        public ActionResult AddRezervation(Rezervation p)
        {
            rm.RezervationAdd(p);
            return RedirectToAction("Index");
        }

 
        public ActionResult DeleteRezervation(int id)//artık sil butonuna tıkladığımızda id yi alıyoruz.
        {
            var RezervationValue = rm.GetByID(id);
            rm.RezervationDelete(RezervationValue);//gönderilen id deki veriler silinir.
            return RedirectToAction("Index");
        }

    }
}