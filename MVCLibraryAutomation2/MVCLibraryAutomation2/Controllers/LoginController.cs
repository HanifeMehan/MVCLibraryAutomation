using DataAccesLayer.Conrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCLibraryAutomation2.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && 
            x.AdminPasswoed == p.AdminPasswoed);
            if (adminuserinfo != null)
            {
                //  FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);//Sisteme giriş yapacak kişinin bilgileri ayarlanıyor
                //  Session["AdminUserName"]=adminuserinfo.AdminUserName; //Oturum yönetimi oluşturuluyor.
                Session["LoginUser"] = adminuserinfo;
                return RedirectToAction("Index", "AdminCategory");

            }
            else
            {
                return RedirectToAction("ındex");
            }
           
        }
    }
}