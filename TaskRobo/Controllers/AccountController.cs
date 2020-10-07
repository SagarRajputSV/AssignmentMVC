using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRobo.Controllers
{
    public class AccountController : Controller
    {
        public TaskDbContext contextobj = new TaskDbContext();

        
        [HttpGet]
        public ActionResult Register()
        {
            if(Session["User"]==null)
            {
                AppUser appuser = new AppUser();
                return View("Register", appuser);
            }

            else
            {
                return RedirectToAction("Index", "Categories");
            }
        }

        [HttpPost]
        public ActionResult Register(AppUser appUser)
        {
            AppUser appuser = new AppUser();
            if (!ModelState.IsValid)
            {
                
                appuser = appUser;
                return View(appuser);
            }   

            if(!DoesUserExist(appUser))
            {
                appuser.EmailId = appUser.EmailId;
                appuser.Password = appUser.Password;

                contextobj.AppUsers.Add(appuser);
                contextobj.SaveChanges();

                return View("Login");
            }

            else
            {
                ViewBag.Invalid =string.Format("The account of the Email Id: {0} already exist",appUser.EmailId);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {

            if(!ModelState.IsValid)
            {
                return View(appUser);
            }

            if(!DoesUserExist(appUser))
            {
                ViewBag.Invalid = "Account does not exist";
                return View();
            }

            IList<AppUser> appuserList = contextobj.AppUsers.ToList();
            foreach (var user in appuserList)
            {
                if (user.EmailId == appUser.EmailId && user.Password == appUser.Password)
                {
                    Session["User"] = appUser;
                    return RedirectToAction("Index", "Categories", appUser);
                }                                
                    
            }

            ViewBag.Invalid = "Email Id and password does not match";
            return View();

        }

        public bool DoesUserExist(AppUser appUser)
        {
            IList<AppUser> appuserList = contextobj.AppUsers.ToList();

            foreach (var user in appuserList)
            {
                if (user.EmailId == appUser.EmailId)
                    return true;
            }

            return false;
        }

    }
}
