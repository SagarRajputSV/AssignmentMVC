using System.Collections.Generic;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public interface ITaskRepository
    {
        int SaveTask(UserTask task);
        int DeleteTask(string email,int taskId);
        IReadOnlyList<UserTask> GetAllTasks(string email);
        UserTask GetTaskById(string email,int taskId);
        int UpdateTask(UserTask task);
    }
}
