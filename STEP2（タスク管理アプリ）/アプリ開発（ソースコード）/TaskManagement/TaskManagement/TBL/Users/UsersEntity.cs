using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    /// <summary>ユーザーテーブルのエンティティ</summary>
    internal class UsersEntity
    {
        public String StrUserId { get; set; }
        public String StrUserName { get; set; }
        public String StrPassword { get; set; }
    }
}
