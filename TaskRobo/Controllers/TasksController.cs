using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
                AppUser appuser = (AppUser)Session["User"];
                if(appuser.EmailId == emailId)
                {
                    List<UserTask> usertaskList = contextobj.UserTasks.ToList();

                    if (usertaskList.Count > 0)
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
                return RedirectToAction("Login", "AppUser");
            }
            else
            {
                return RedirectToAction("Login", "AppUser");
            }
        }

        [HttpGet]
        public ActionResult Add(string emailid, string categoryid)
        {
            if(Session["User"]!=null)
            {
                AppUser appuser = (AppUser)Session["User"];
                if(appuser.EmailId == emailid)
                {
                    ViewBag.UserInfo = Session["User"];
                    UserTask usertask = new UserTask();
                    usertask.EmailId = emailid;
                    usertask.CategoryId = Convert.ToInt32(categoryid);
                    return View(usertask);
                }
                else
                {
                    return RedirectToAction("Login", "AppUser");
                }
               
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Add(UserTask usertask)
        {
            if(Session["User"]!=null)
            {
                AppUser appuser = (AppUser)Session["User"];

                if (appuser.EmailId == usertask.EmailId)
                {
                    if(usertask.TaskId == 0)
                    {
                        UserTask usertaskDb = new UserTask();
                        usertaskDb.TaskTitle = usertask.TaskTitle;
                        usertaskDb.TaskContent = usertask.TaskContent;
                        usertaskDb.TaskStatus = usertask.TaskStatus;
                        usertaskDb.EmailId = usertask.EmailId;
                        usertaskDb.CategoryId = usertask.CategoryId;

                        contextobj.UserTasks.Add(usertaskDb);
                        contextobj.SaveChanges();
                    }

                    else
                    {
                        contextobj.UserTasks.AddOrUpdate(usertask);
                        contextobj.SaveChanges();
                    }
                    
                    return RedirectToAction("Index", "Tasks", new { emailId = usertask.EmailId, categoryid = usertask.CategoryId });
                }

                else
                    return RedirectToAction("Login", "AppUser");
            }

            return RedirectToAction("Login", "AppUser");
        }
          
        [HttpGet]
        public ActionResult Edit(int TaskId, string EmailId)
        {
            if(Session["User"]!=null)
            {
                AppUser appuser = (AppUser)Session["User"];
                if(appuser.EmailId == EmailId)
                {
                    UserTask usertask = contextobj.UserTasks.SingleOrDefault(u => u.EmailId == EmailId && u.TaskId == TaskId);
                    return View("Add",usertask);
                }
            }
            return View("Login", "Account");
        }

        public ActionResult Delete(int TaskId,string EmailId)
        {
            if(Session["User"]!=null)
            {
                AppUser appuser = (AppUser)Session["User"];

                if(appuser.EmailId.ToString().Equals(EmailId))
                {
                    UserTask usertask = contextobj.UserTasks.SingleOrDefault(u => u.EmailId == EmailId && u.TaskId == TaskId);
                    contextobj.UserTasks.Remove(usertask);
                    contextobj.SaveChanges();

                    return RedirectToAction("Index","Tasks",new { emailid = EmailId, categoryid = usertask.CategoryId});
                }
                return View("Login", "Account");
            }

            else
            {
                return View("Login", "Account");
            }
        }
    }
}
