using MySql.Data.MySqlClient;

namespace TaskManagementWeb.Services
{
    public class TaskTagService
    {
        private readonly IConfiguration _config;

        public TaskTagService(IConfiguration config)
        {
            _config = config;
        }

        public Dictionary<int, string> GetTagDictionary()
        {
            var result = new Dictionary<int, string>();
            using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            conn.Open();

            using var cmd = new MySqlCommand("SELECT tag_no, tag_name FROM task_tags", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int tagNo = Convert.ToInt32(reader["tag_no"]);
                string tagName = reader["tag_name"].ToString();
                result[tagNo] = tagName;
            }

            return result;
        }
    }

}
