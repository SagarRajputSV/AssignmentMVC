using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class TaskRepository:ITaskRepository
    {
        readonly TaskDbContext context;
        public TaskRepository(TaskDbContext _context)
        {
            context = _context;
        }

        // This method should be used to delete task details from database based upon user's email & task id
        public int DeleteTask(string email, int taskId)
        {
            UserTask userTask = GetTaskById(email,taskId);
            context.UserTasks.Remove(userTask);
            return 0;
        }

        // This method should be used to get all task details from database based upon user's email
        public IReadOnlyList<UserTask> GetAllTasks(string email)
        {
            var readonlyList = context.UserTasks.Select(x => x.EmailId == email);
            var list = readonlyList as List<UserTask>;
            return list.AsReadOnly();
        }

        // This method should be used to get task details from database based upon user's email and task id
        public UserTask GetTaskById(string email, int taskId)
        {
            UserTask userTask = context.UserTasks.FirstOrDefault(x => x.EmailId == email && x.TaskId == taskId);
            return userTask;
        }

        // This method should be used to save task details into database 
        public int SaveTask(UserTask task)
        {
            var result = context.UserTasks.Add(task);
            return context.SaveChanges();
        }

        // This method should be used to update task details into database
        public int UpdateTask(UserTask task)
        {
            context.UserTasks.AddOrUpdate(task);
            return context.SaveChanges();
        }
    }
}