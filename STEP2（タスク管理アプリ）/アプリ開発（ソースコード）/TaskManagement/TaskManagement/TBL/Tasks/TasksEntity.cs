using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    /// <summary>タスクテーブルのエンティティ</summary>
    public class TasksEntity
    {
        public int IntTaskNo { get; set; }
        public int IntUserId { get; set; }
        public String StrTaskName { get; set; }
        public String StrDescription { get; set; }
        public int IntTagNo { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean IsActive { get; set; }
        public String StrTagName { get; set; }
    }
}
