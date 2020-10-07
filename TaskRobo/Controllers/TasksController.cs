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

        // Index action method should return view along with all tasks based upon the logged in user
        

        // Details action method should retrieve tasks data from database based upon the logged in user and id
        // if success, return view with task details else return not found status
       

        // Create action method should get all categories from database based upon logged in user
        // and return view
       

        // Create action method should handle post request and store task details in database. 
        // If success redirect to index action method else return view with model
       

        // Edit action method should retrieve task details from database based upon logged in user and id
        // If success return view along with task details else return not found status
     
        // Edit action should handle post request and modify the task details into database.
        // If success redirect to index action method else return view with model.
        
        
        // Delete action method should retrieve task details from database based upon logged in user and id
        // If success return view with task details else return not found status
    
        // DeleteConfirmed action method should handle post request. Action name should be given as Delete using attribute.
        // This method should delete task details from database based upon logged in user and id then return to index
              
    }
}
