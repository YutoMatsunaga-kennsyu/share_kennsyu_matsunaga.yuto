using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using TaskManagement;

namespace TaskManagement
{
    public class TasksDao
    {

        public List<TasksEntity> SelectAll(String userId)
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "SELECT task_no, task_name, description, tag_name, due_date, done_date, update_date, is_active FROM tasks tasks INNER JOIN task_tags tags on tasks.tag_no = tags.tag_no WHERE tasks.is_active = '1' AND tasks.user_id = @userId ORDER BY ABS(DATEDIFF(due_date, CURDATE()));";

            // 在庫マスタエンティティのリスト
            List<TasksEntity> tasksEntityList = new();
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {

                using var command = new MySqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@userId", userId);
                // SQLを実行し、結果を取得
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader["done_date"].Equals(DBNull.Value))
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            tagName = (string)reader["tag_name"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = (DateTime)reader["done_date"],
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                    else
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            tagName = (string)reader["tag_name"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = null,
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                }

                // 在庫マスタエンティティのリスト
                return tasksEntityList;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }

        public List<TasksEntity> SelectMatch(String taskName, String tag, String dateFrom, String dateTo, String dateDone, String active, String userId)
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText1 = "SELECT task_no, task_name, description, tag_name, due_date, done_date, update_date, is_active FROM tasks tasks INNER JOIN task_tags tags on tasks.tag_no = tags.tag_no ";
            var commandText2 = "ORDER BY ABS(DATEDIFF(due_date, CURDATE()));";
            var whereText = "WHERE ";

            if (!String.IsNullOrEmpty(taskName))
            {
                whereText += "task_name LIKE @taskName AND ";
            }

            if (!tag.Equals("全て"))
            {
                whereText += "tag_name = @tag AND ";
            }
            
            if(!String.IsNullOrEmpty(dateFrom) && !String.IsNullOrEmpty(dateTo))
            {
                whereText += "due_date BETWEEN @dateFrom AND @dateTo AND ";
            } 
            else if (!String.IsNullOrEmpty(dateFrom))
            {
                whereText += "due_date >= @dateFrom AND ";
            }
            else if (!String.IsNullOrEmpty(dateTo))
            {
                whereText += "due_date <= @dateTo AND ";
            }

            if (!String.IsNullOrEmpty(dateDone))
            {
                whereText += "DATE_FORMAT(done_date, '%Y/%m/%d') = @dateDone AND ";
            }

            if (!active.Equals("全て"))
            {
                whereText += "is_active = @active AND ";
            }

            whereText += "user_id = @userId ";

            var commandText = commandText1 + whereText + commandText2;
 

            // 在庫マスタエンティティのリスト
            List<TasksEntity> tasksEntityList = new();

            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                if (!String.IsNullOrEmpty(taskName))
                {
                    command.Parameters.AddWithValue("@taskName", "%" + taskName + "%");
                }

                if (!tag.Equals("全て"))
                {
                    command.Parameters.AddWithValue("@tag", tag);
                }

                if (!String.IsNullOrEmpty(dateFrom) && !String.IsNullOrEmpty(dateTo))
                {
                    command.Parameters.AddWithValue("@dateFrom", dateFrom);
                    command.Parameters.AddWithValue("@dateTo", dateTo);
                }
                else if (String.IsNullOrEmpty(dateFrom))
                {
                    command.Parameters.AddWithValue("@dateTo", dateTo);
                }
                else
                {
                    command.Parameters.AddWithValue("@dateFrom", dateFrom);
                }

                if (!String.IsNullOrEmpty(dateDone))
                {
                    command.Parameters.AddWithValue("@dateDone", dateDone);
                }

                if (!active.Equals("全て"))
                {
                    if (active.Equals("未完了"))
                    {
                        command.Parameters.AddWithValue("@active", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@active", 0);
                    }
                    
                }

                command.Parameters.AddWithValue("@userId", userId);

                // SQLを実行し、結果を取得
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader["done_date"].Equals(DBNull.Value))
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            tagName = (string)reader["tag_name"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = (DateTime)reader["done_date"],
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                    else
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            tagName = (string)reader["tag_name"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = null,
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                }

                // 在庫マスタエンティティのリスト
                return tasksEntityList;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }

        public void DeleteTask(int taskNo)
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "DELETE FROM tasks WHERE task_no = @taskNo";

            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@taskNo", taskNo);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }

        public void CreateTask(String taskName, String description, int tagNo, String dueDate ,String userId)
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "INSERT INTO tasks(user_id, task_name, description, tag_no, due_date, update_date, is_active) VALUES ( @userId, @taskName, @description, @tagNo, @dueDate, SYSDATE(), '1')";

            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@taskName", taskName);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@tagNo", tagNo);
                command.Parameters.AddWithValue("@dueDate", dueDate);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }



        public void CompleteTask(int taskNo)
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "UPDATE tasks SET done_date = SYSDATE(), update_date = SYSDATE(), is_active = 0 WHERE task_no = @taskNo";

            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@taskNo", taskNo);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }

        public Boolean IsComplete(int taskNo)
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "SELECT * FROM tasks WHERE task_no = @taskNo AND is_active = 0";

            // 在庫マスタエンティティのリスト
            List<TasksEntity> tasksEntityList = new();

            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {

                using var command = new MySqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@taskNo", taskNo);
                // SQLを実行し、結果を取得
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader["done_date"].Equals(DBNull.Value))
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = (DateTime)reader["done_date"],
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                    else
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = null,
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                }

                if (tasksEntityList?.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }

        public List<TasksEntity> getTaskInformation(int taskNo)
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "SELECT task_no, task_name, description, tag_no, due_date, done_date, update_date, is_active FROM tasks WHERE task_no = @taskNo;";

            // 在庫マスタエンティティのリスト
            List<TasksEntity> tasksEntityList = new();
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@taskNo", taskNo);
                // SQLを実行し、結果を取得
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader["done_date"].Equals(DBNull.Value))
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            tagNo = (int)reader["tag_no"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = (DateTime)reader["done_date"],
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                    else
                    {
                        tasksEntityList.Add(new TasksEntity()
                        {
                            taskNo = (int)reader["task_no"],
                            taskName = (string)reader["task_name"],
                            description = (string)reader["description"],
                            tagNo = (int)reader["tag_no"],
                            dueDate = (DateTime)reader["due_date"],
                            doneDate = null,
                            updateDate = (DateTime)reader["update_date"],
                            isActive = (Boolean)reader["is_active"],
                        });
                    }
                }

                // 在庫マスタエンティティのリスト
                return tasksEntityList;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }
    }
}


