using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementWeb.Models
{
    public class TaskModel
    {
        public int TaskNo { get; set; }

		public string TaskName { get; set; } = string.Empty;
		public string TempTaskName { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;
		public string TempDescription { get; set; } = string.Empty;

        public int TagNo { get; set; }
        public string TagName { get; set; }
        public DateTime? DueDate { get; set; }

		public string? DueDateString
		{
			get => DueDate?.ToString("yyyy-MM-ddTHH:mm");
			set => DueDate = DateTime.TryParse(value, out var dt) ? dt : null;
		}

		public DateTime? DoneDate { get; set; }

		public string? DoneDateString
		{
			get => DoneDate?.ToString("yyyy-MM-ddTHH:mm");
			set => DoneDate = DateTime.TryParse(value, out var dt) ? dt : null;
		}

		public DateTime? UpdateDate { get; set; }
        public int IsActive { get; set; }
        public bool IsChecked { get; set; }
	}
}