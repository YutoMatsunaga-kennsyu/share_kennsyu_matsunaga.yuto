using MySql.Data.MySqlClient;
using TaskManagementWeb.Models;

namespace TaskManagementWeb.Repositories
{
	/// <summary>ユーザー情報にアクセスするリポジトリ</summary>
	public class UserRepository
	{
		private readonly string _connectionString;

		public UserRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection")!;
		}

		/// <summary>ログイン認証：ユーザーIDとパスワードから一致するユーザーを取得</summary>
		public async Task<User?> AuthenticateAsync(string userId, string password)
		{
			const string sql = "SELECT * FROM users WHERE user_id = @userId AND password = @password";

			using var connection = new MySqlConnection(_connectionString);
			await connection.OpenAsync();

			try
			{
				using var command = new MySqlCommand(sql, connection);
				command.Parameters.AddWithValue("@userId", userId);
				command.Parameters.AddWithValue("@password", password);

				using var reader = await command.ExecuteReaderAsync();
				if (await reader.ReadAsync())
				{
					return new User
					{
						UserId = reader["user_id"].ToString() ?? "",
						UserName = reader["user_name"].ToString() ?? "",
						Password = reader["password"].ToString() ?? "",
					};
				}

				return null;
			}
			catch (Exception ex)
			{
				// TODO: ログに出すなど
				return null;
			}
		}
	}
}
