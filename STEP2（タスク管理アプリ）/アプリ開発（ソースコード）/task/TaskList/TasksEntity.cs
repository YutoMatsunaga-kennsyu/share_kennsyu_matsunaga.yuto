using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class TasksEntity
    {
        public int taskNo { get; set; }
        public int userNo { get; set; }
        public String taskName { get; set; }
        public String description { get; set; }
        public int tagNo { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime? doneDate { get; set; }
        public DateTime updateDate { get; set; }
        public Boolean isActive { get; set; }
        public String tagName { get; set; }
    }
}
