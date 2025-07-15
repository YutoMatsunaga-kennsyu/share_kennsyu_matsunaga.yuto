namespace TaskManagementWeb.Services
{
	/// <summary>現在のログインユーザーの状態を保持するサービス</summary>
	public class UserSessionService
	{
		public string? UserId { get; set; }
		public string? UserName { get; set; }

		public bool IsLoggedIn => !string.IsNullOrEmpty(UserId);

		public void Clear()
		{
			UserId = null;
			UserName = null;
		}
	}
}