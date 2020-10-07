using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRobo.Controllers
{
    public class TasksController : Controller
    {
        /*
           * Implement the below mentioned methods as per mentioned requiremetns.
       */
        public TaskDbContext contextobj = new TaskDbContext();
        // Index action method should return view along with all tasks based upon the logged in user
        public ActionResult Index(string emailId,int categoryid)
        {
            if(Session["User"]!=null)
            {
                List<UserTask> usertaskList = contextobj.UserTasks.ToList();

                if(usertaskList.Count>0)
                {
                    foreach (UserTask userTask in usertaskList)
                    {
                        if (userTask.EmailId != emailId && userTask.CategoryId != categoryid)
                        {
                            usertaskList.Remove(userTask);
                        }
                    }
                }
                ViewBag.EmailId = emailId;
                ViewBag.CategoryId = categoryid;
                return View(usertaskList);

            }
            else
            {
                return RedirectToAction("Index", "Categories");
            }
        }

        [HttpGet]
        public ActionResult Add(string emailid, string categoryid)
        {
            if(Session["User"]!=null)
            {
                ViewBag.UserInfo = Session["User"];
                UserTask usertask = new UserTask();
                usertask.EmailId = emailid;
                usertask.CategoryId = Convert.ToInt32(categoryid);
                return View(usertask);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Add(UserTask usertask)
        {

            UserTask usertaskDb = new UserTask();
            usertaskDb.TaskTitle = usertask.TaskTitle;
            usertaskDb.TaskContent = usertask.TaskContent;
            usertaskDb.TaskStatus = usertask.TaskStatus;
            usertaskDb.EmailId = usertask.EmailId;
            usertaskDb.CategoryId = usertask.CategoryId;

            contextobj.UserTasks.Add(usertaskDb);
            contextobj.SaveChanges();

            return RedirectToAction("Index","Tasks",new { emailId =usertask.EmailId,categoryid = usertask.CategoryId});
        }
              
    }
}
