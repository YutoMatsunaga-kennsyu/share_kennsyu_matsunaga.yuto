using TaskManagementWeb.Models;
using TaskManagementWeb.Repositories;

namespace TaskManagementWeb.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepo;
        private readonly TaskTagRepository _tagRepo;

        public TaskService(TaskRepository taskRepo, TaskTagRepository tagRepo)
        {
            _taskRepo = taskRepo;
            _tagRepo = tagRepo;
        }

        public List<TaskModel> LoadTasks(string userId)
        {
            var tasks = _taskRepo.GetTasksByUserId(userId);
            var tagDict = _tagRepo.GetAllTags();

            foreach (var task in tasks)
            {
                task.TagName = tagDict.ContainsKey(task.TagNo) ? tagDict[task.TagNo] : "未分類";
            }

            return tasks;
        }

		public async Task<TaskModel?> LoadTaskByIdAsync(int taskNo)
		{
			return await _taskRepo.LoadTaskByIdAsync(taskNo);
		}

		public async Task<List<TaskModel>> SearchTasksAsync(
	string taskName,
	string tagName,
	string dateFrom,
	string dateTo,
	string dateDone,
	string active,
	string userId)
		{
			var tasks = await _taskRepo.GetTasksByConditionsAsync(
				taskName, tagName, dateFrom, dateTo, dateDone, active, userId);

			var tagDict = _tagRepo.GetAllTags();

			foreach (var task in tasks)
			{
				task.TagName = tagDict.ContainsKey(task.TagNo) ? tagDict[task.TagNo] : "未分類";
			}

			return tasks;
		}

		public async Task UpdateTask(TaskModel task)
        {
            await _taskRepo.UpdateTaskAsync(task);
        }

		public void CompleteTasks(List<TaskModel> tasks)
        {
            _taskRepo.CompleteTasks(tasks);
        }

        public void DeleteTasks(List<TaskModel> tasks)
        {
            _taskRepo.DeleteTasks(tasks);
        }
    }
}
