namespace TaskManagementWeb.Models
{
	/// <summary>ユーザー情報を表すモデル</summary>
	public class User
	{
		/// <summary>ユーザーID（主キー）</summary>
		public string UserId { get; set; } = string.Empty;

		/// <summary>ユーザー名</summary>
		public string UserName { get; set; } = string.Empty;

		/// <summary>パスワード（ハッシュ前提）</summary>
		public string Password { get; set; } = string.Empty;
	}
}
