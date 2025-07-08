using WebTaskManagement.Models;
using WebTaskManagement.Repositories;

namespace WebTaskManagement.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;

        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskModel> LoadTasks(string userId)
        {
            return _taskRepository.GetTasks(userId);
        }

        public List<TaskModel> GetPagedTasks(List<TaskModel> allTasks, int pageIndex, int pageSize)
        {
            return allTasks.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public async Task UpdateTask(TaskModel task)
        {
            await _taskRepository.UpdateTaskAsync(task);
        }

        public void CompleteTasks(List<TaskModel> tasks)
        {
            _taskRepository.CompleteTasks(tasks);
        }

        public void DeleteTasks(List<TaskModel> tasks)
        {
            _taskRepository.DeleteTasks(tasks);
        }
    }
}
