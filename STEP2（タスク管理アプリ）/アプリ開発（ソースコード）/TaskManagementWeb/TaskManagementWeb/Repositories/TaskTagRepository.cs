using MySql.Data.MySqlClient;

public class TaskTagRepository
{
    private readonly IConfiguration _config;

    public TaskTagRepository(IConfiguration config)
    {
        _config = config;
    }

    public Dictionary<int, string> GetAllTags()
    {
        var result = new Dictionary<int, string>();

        using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
        conn.Open();

        using var cmd = new MySqlCommand("SELECT tag_no, tag_name FROM task_tags", conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            result[Convert.ToInt32(reader["tag_no"])] = reader["tag_name"].ToString();
        }

        return result;
    }
}
