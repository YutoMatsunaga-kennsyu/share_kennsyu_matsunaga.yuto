using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class TasksEntity
    {
        public String taskName { get; set; }
        public String description { get; set; }
        public String tag { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime? doneDate { get; set; }
        public DateTime updateDate { get; set; }
        public String active { get; set; }
    }
}
