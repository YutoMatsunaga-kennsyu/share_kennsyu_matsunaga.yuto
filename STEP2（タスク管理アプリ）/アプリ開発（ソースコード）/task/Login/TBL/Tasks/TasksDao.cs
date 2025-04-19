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
    /// <summary>タスクテーブルのDAO</summary>
    public class TasksDao
    {
        /// <summary>タスクテーブルの全検索処理</summary>
        /// <param name="strUserId"></param>
        /// <returns>タスクテーブルの全検索結果</returns>
        public List<TasksEntity> SelectAll(String strUserId)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // タスクエンティティのリスト
            List<TasksEntity> tasksEntityList = new();

            // 実行クエリ
            var commandText = "SELECT task_no, task_name, description, tag_name,  tasks.tag_no, due_date, done_date, update_date, is_active FROM tasks tasks INNER JOIN task_tags tags on tasks.tag_no = tags.tag_no WHERE tasks.is_active = '1' AND tasks.user_id = @userId ORDER BY ABS(DATEDIFF(due_date, CURDATE()));";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // パラメータの設定
                command.Parameters.AddWithValue("@userId", strUserId);

                // クエリ実行
                using var reader = command.ExecuteReader();

                // クエリの実行結果をタスクエンティティのリストに格納
                return GetTasksEntityList(reader);
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

        /// <summary>タスクテーブルの条件付き検索処理</summary>
        /// <param name="strTaskName"></param>
        /// <param name="strTag"></param>
        /// <param name="strDateFrom"></param>
        /// <param name="strDateTo"></param>
        /// <param name="strDateDone"></param>
        /// <param name="strActive"></param>
        /// <param name="strUserId"></param>
        /// <returns>タスクテーブルの全検索結果</returns>
        public List<TasksEntity> SelectMatch(String strTaskName, String strTag, String strDateFrom, String strDateTo, String strDateDone, String strActive, String strUserId)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // タスクエンティティのリスト
            List<TasksEntity> tasksEntityList = new();

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 実行SQL
            var commandTextSelect = "SELECT task_no, task_name, description, tag_name,  tasks.tag_no, due_date, done_date, update_date, is_active FROM tasks tasks INNER JOIN task_tags tags on tasks.tag_no = tags.tag_no ";
            var commandTextOrderBy = "ORDER BY ABS(DATEDIFF(due_date, CURDATE()));";
            var commandTextWhere = "WHERE ";

            // タスク名検索欄に値が入力されていた場合
            if (!String.IsNullOrEmpty(strTaskName))
            {
                commandTextWhere += "task_name LIKE @taskName AND ";
            }

            // タスク分類検索欄が「全て」以外の場合
            if (!strTag.Equals("全て"))
            {
                commandTextWhere += "tag_name = @tag AND ";
            }

            // タスク完了期限検索欄（開始日）と、タスク完了期限検索欄（終了日）が入力されている場合
            if (!String.IsNullOrEmpty(strDateFrom) && !String.IsNullOrEmpty(strDateTo))
            {
                commandTextWhere += "due_date BETWEEN @dateFrom AND @dateTo AND ";
            }
            // タスク完了期限検索欄（開始日）が入力されている場合
            else if (!String.IsNullOrEmpty(strDateFrom))
            {
                commandTextWhere += "due_date >= @dateFrom AND ";
            }
            // タスク完了期限検索欄（終了日）が入力されている場合
            else if (!String.IsNullOrEmpty(strDateTo))
            {
                commandTextWhere += "due_date <= @dateTo AND ";
            }

            // タスク完了日検索欄に値が入力されていた場合
            if (!String.IsNullOrEmpty(strDateDone))
            {
                commandTextWhere += "DATE_FORMAT(done_date, '%Y/%m/%d') = @dateDone AND ";
            }

            // タスク状況検索欄が「全て」以外の場合
            if (!strActive.Equals("全て"))
            {
                commandTextWhere += "is_active = @active AND ";
            }

            commandTextWhere += "user_id = @userId ";

            // 実行SQL
            var commandText = commandTextSelect + commandTextWhere + commandTextOrderBy;

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // パラメータの設定
                if (!String.IsNullOrEmpty(strTaskName))
                {
                    command.Parameters.AddWithValue("@taskName", "%" + strTaskName + "%");
                }

                if (!strTag.Equals("全て"))
                {
                    command.Parameters.AddWithValue("@tag", strTag);
                }

                if (!String.IsNullOrEmpty(strDateFrom) && !String.IsNullOrEmpty(strDateTo))
                {
                    command.Parameters.AddWithValue("@dateFrom", strDateFrom);
                    command.Parameters.AddWithValue("@dateTo", strDateTo);
                }
                else if (String.IsNullOrEmpty(strDateFrom))
                {
                    command.Parameters.AddWithValue("@dateTo", strDateTo);
                }
                else
                {
                    command.Parameters.AddWithValue("@dateFrom", strDateFrom);
                }

                if (!String.IsNullOrEmpty(strDateDone))
                {
                    command.Parameters.AddWithValue("@dateDone", strDateDone);
                }

                if (!strActive.Equals("全て"))
                {
                    if (strActive.Equals("未完了"))
                    {
                        command.Parameters.AddWithValue("@active", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@active", 0);
                    }
                }

                command.Parameters.AddWithValue("@userId", strUserId);

                // クエリ実行
                using var reader = command.ExecuteReader();

                // クエリの実行結果をタスクエンティティのリストに格納
                return GetTasksEntityList(reader);
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

        /// <summary>一覧画面でチェックしたタスクを削除する処理</summary>
        /// <param name="checkedTaskNo">タスク番号</param>
        public void DeleteTask(List<int> checkedTaskNo)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // 実行クエリ
            var commandTextDelete = "DELETE FROM tasks ";
            var commandTextWhere = "WHERE task_no IN(";

            // 引数のタスク番号を抽出条件に加える
            foreach (var taskNo in checkedTaskNo)
            {
                commandTextWhere += "'" + taskNo + "', ";
            }

            // 抽出条件の末尾の不要なカンマ、半角スペースを削除する
            var modifiedTextWhere = commandTextWhere.Substring(0, commandTextWhere.Length - 2) + ");";

            // 実行クエリ
            var commandText = commandTextDelete + modifiedTextWhere;

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // クエリ実行
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

        /// <summary>一覧画面でチェックしたタスクを完了済みにする処理</summary>
        /// <param name="checkedTaskNo">タスク番号</param>
        public void CompleteTask(List<int> checkedTaskNo)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // 実行クエリ
            var commandTextUpdate = "UPDATE tasks SET done_date = SYSDATE(), update_date = SYSDATE(), is_active = 0 ";
            var commandTextWhere = "WHERE task_no IN(";

            // 引数のタスク番号を抽出条件に加える
            foreach (var taskNo in checkedTaskNo)
            {
                commandTextWhere += "'" + taskNo + "', ";
            }

            // 抽出条件の末尾の不要なカンマ、半角スペースを削除する
            var modifiedTextWhere = commandTextWhere.Substring(0, commandTextWhere.Length - 2) + ");";

            // 実行クエリ
            var commandText = commandTextUpdate + modifiedTextWhere;

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // クエリ実行
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

        /// <summary>新規タスクの登録を行う処理</summary>
        /// <param name="strTaskName">タスク名</param>
        /// <param name="strDescription">説明</param>
        /// <param name="intTagNo">タスク分類番号</param>
        /// <param name="strDueDate">タスク完了期限</param>
        /// <param name="strUserId">ユーザーID</param>
        public void CreateTask(String strTaskName, String strDescription, int intTagNo, String strDueDate, String strUserId)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // 実行クエリ
            var commandText = "INSERT INTO tasks(user_id, task_name, description, tag_no, due_date, update_date, is_active) VALUES ( @userId, @taskName, @description, @tagNo, @dueDate, SYSDATE(), '1')";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // パラメータの設定
                command.Parameters.AddWithValue("@userId", strUserId);
                command.Parameters.AddWithValue("@taskName", strTaskName);
                command.Parameters.AddWithValue("@description", strDescription);
                command.Parameters.AddWithValue("@tagNo", intTagNo);
                command.Parameters.AddWithValue("@dueDate", strDueDate);

                // クエリ実行
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

        /// <summary>一覧画面でタスク名のリンクを押下したタスクの修正を行う処理</summary>
        /// <param name="intLinkTaskNo">一覧画面でタスク名のリンクを押下したタスクのタスク番号</param>
        /// <param name="strTaskName">修正後のタスク名</param>
        /// <param name="strDescription">修正後の説明</param>
        /// <param name="intTagNo">修正後のタスク分類番号</param>
        /// <param name="strDueDate">修正後のタスク完了期限</param>
        /// <param name="prevIsActive">修正前のタスク状況</param>
        /// <param name="strUpdatedActive">修正後のタスク状況</param>
        public void UpdateTask(int intLinkTaskNo, String strTaskName, String strDescription, int intTagNo, String strDueDate, Boolean prevIsActive, String strUpdatedActive)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // 実行クエリ
            var commandText = "";

            // タスク修正前のタスク状況が「true(未完了)」かつ、タスク修正後のタスク状況が「完了」の場合
            if (prevIsActive == true && strUpdatedActive.Equals("完了"))
            {
                commandText = "UPDATE tasks SET task_name = @taskName, description = @description, tag_no = @tagNo, due_date = @dueDate, done_date = SYSDATE(), update_date = SYSDATE(), is_active = '0' WHERE task_no = @taskNo";
            }
            // タスク修正前のタスク状況が「false(完了)」かつ、タスク修正後のタスク状況が「未完了」の場合
            else if (prevIsActive == false && strUpdatedActive.Equals("未完了"))
            {
                commandText = "UPDATE tasks SET task_name = @taskName, description = @description, tag_no = @tagNo, due_date = @dueDate, done_date = NULL, update_date = SYSDATE(), is_active = '1' WHERE task_no = @taskNo";
            }
            else
            {
                commandText = "UPDATE tasks SET task_name = @taskName, description = @description, tag_no = @tagNo, due_date = @dueDate, update_date = SYSDATE() WHERE task_no = @taskNo";
            }

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // パラメータの設定
                command.Parameters.AddWithValue("@taskName", strTaskName);
                command.Parameters.AddWithValue("@description", strDescription);
                command.Parameters.AddWithValue("@tagNo", intTagNo);
                command.Parameters.AddWithValue("@dueDate", strDueDate);
                command.Parameters.AddWithValue("@taskNo", intLinkTaskNo);

                // クエリ実行
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

        /// <summary>引数のタスク番号のタスクが完了済みか判定する処理</summary>
        /// <param name="intTaskNo">タスク番号</param>
        /// <returns>引数のタスク番号のタスクが完了済みかの判定結果</returns>
        public Boolean IsComplete(int intTaskNo)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // タスクエンティティのリスト
            List<TasksEntity> tasksEntityList = new();

            // 実行クエリ
            var commandText = "SELECT task_no, task_name, description, tag_name, tasks.tag_no, due_date, done_date, update_date, is_active FROM tasks tasks INNER JOIN task_tags tags on tasks.tag_no = tags.tag_no WHERE task_no = @taskNo AND is_active = 0";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // パラメータの設定
                command.Parameters.AddWithValue("@taskNo", intTaskNo);

                // クエリ実行
                using var reader = command.ExecuteReader();

                // クエリの実行結果をタスクエンティティのリストに格納
                tasksEntityList = GetTasksEntityList(reader);

                // タスクエンティティのリストが空かNULLの場合はtrue
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

        /// <summary>引数のタスク番号のタスクエンティティのリストを返す処理</summary>
        /// <param name="intTaskNo">タスク番号</param>
        /// <returns>引数のタスク番号のタスクエンティティのリスト</returns>
        public List<TasksEntity> GetTaskInformation(int intTaskNo)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // 実行クエリ
            var commandText = "SELECT task_no, task_name, description, tag_name, tasks.tag_no, due_date, done_date, update_date, is_active FROM tasks tasks INNER JOIN task_tags tags on tasks.tag_no = tags.tag_no WHERE task_no = @taskNo;";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // パラメータの設定
                command.Parameters.AddWithValue("@taskNo", intTaskNo);

                // クエリ実行
                using var reader = command.ExecuteReader();

                // クエリの実行結果をタスクエンティティのリストに格納
                return GetTasksEntityList(reader);
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

        /// <summary>クエリの実行結果をタスクエンティティのリストに格納する処理</summary>
        /// <param name="reader">クエリの実行結果</param>
        /// <returns>クエリの実行結果が格納されたタスクエンティティのリスト</returns>
        public List<TasksEntity> GetTasksEntityList(MySqlDataReader reader)
        {
            // タスクエンティティのリスト
            List<TasksEntity> tasksEntityList = new();

            // クエリの実行結果をタスクエンティティのリストに格納
            while (reader.Read())
            {
                // タスク完了日がNULLの場合
                if (!reader["done_date"].Equals(DBNull.Value))
                {
                    tasksEntityList.Add(new TasksEntity()
                    {
                        IntTaskNo = (int)reader["task_no"],
                        StrTaskName = (string)reader["task_name"],
                        StrDescription = (string)reader["description"],
                        IntTagNo = (int)reader["tag_no"],
                        StrTagName = (string)reader["tag_name"],
                        DueDate = (DateTime)reader["due_date"],
                        DoneDate = (DateTime)reader["done_date"],
                        UpdateDate = (DateTime)reader["update_date"],
                        IsActive = (Boolean)reader["is_active"],
                    });
                }
                else
                {
                    tasksEntityList.Add(new TasksEntity()
                    {
                        IntTaskNo = (int)reader["task_no"],
                        StrTaskName = (string)reader["task_name"],
                        StrDescription = (string)reader["description"],
                        IntTagNo = (int)reader["tag_no"],
                        StrTagName = (string)reader["tag_name"],
                        DueDate = (DateTime)reader["due_date"],
                        DoneDate = null,
                        UpdateDate = (DateTime)reader["update_date"],
                        IsActive = (Boolean)reader["is_active"],
                    });
                }
            }
           
            return tasksEntityList;
        }
    }
}


