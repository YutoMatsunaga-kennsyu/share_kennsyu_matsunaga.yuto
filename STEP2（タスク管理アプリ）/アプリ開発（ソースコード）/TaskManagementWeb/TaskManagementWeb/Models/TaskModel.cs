namespace WebTaskManagement.Models
{
    public class TaskModel
    {
        public int TaskNo { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string TagName { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsChecked { get; set; }
    }
}