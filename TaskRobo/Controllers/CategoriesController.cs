using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRobo.Controllers
{
    public class CategoriesController : Controller
    {
        public TaskDbContext contexobj = new TaskDbContext();
        [HttpGet]
        public ActionResult Index(AppUser appuser)
        {

            if(Session["User"]!=null)
            {

                IList<Category> categoryList = contexobj.Categories.ToList() ;

                if (categoryList.Count > 0)
                {
                    foreach (var category in categoryList)
                    {
                        if (category.EmailId != appuser.EmailId)
                        {
                            categoryList.Remove(category);
                        }
                    }
                }
                return View(categoryList);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }

        [HttpGet]
        public ActionResult Add()
        {
            if(Session["User"] != null)
            {
                ViewBag.UserInfo = Session["User"];
                Category category = new Category();
                return View(category);
            }
            
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            IList<Category> categoryList = new List<Category>();
            categoryList =(IList<Category>) contexobj.Categories.Include(a => a.AppUser).ToList();

            if(categoryList.Count > 0)
            {
                foreach (Category item in categoryList)
                {
                    if (item.CategoryTitle == category.CategoryTitle)
                    {
                        ViewBag.Invalid =string.Format( "The Category with the title {0} exist",category.CategoryTitle);
                        ViewBag.UserInfo = Session["User"];
                        return View("Add", category);
                    }
                }
            }                

            Category cat = new Category();
            cat.CategoryTitle = category.CategoryTitle;
            cat.EmailId = category.EmailId;

            contexobj.Categories.Add(cat);
            contexobj.SaveChanges();

            AppUser appuser = new AppUser();
            appuser.EmailId = category.EmailId;
            return RedirectToAction("Index",appuser);
        }

        public ActionResult Delete(string emailId,string title)
        {
            var appuser = contexobj.AppUsers.SingleOrDefault(a => a.EmailId == emailId);
            var category = contexobj.Categories.SingleOrDefault(c => c.EmailId == emailId && c.CategoryTitle == title);


            contexobj.Categories.Remove(category);
            contexobj.SaveChanges();

            return RedirectToAction("Index", appuser);
        }
    }
}
