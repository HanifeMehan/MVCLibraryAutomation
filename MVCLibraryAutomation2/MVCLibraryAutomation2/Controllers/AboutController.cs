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
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EFAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var AboutValues = abm.GetList();
            return View(AboutValues);
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
    }
}