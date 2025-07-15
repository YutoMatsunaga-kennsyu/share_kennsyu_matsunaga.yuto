using TaskManagementWeb.Models;
using TaskManagementWeb.Repositories;

namespace TaskManagementWeb.Services
{
	/// <summary>ユーザーに関するビジネスロジックを提供するサービス</summary>
	public class UserService
	{
		private readonly UserRepository _userRepository;

		public UserService(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		/// <summary>
		/// ログイン認証処理。成功時はユーザー情報を返す。
		/// </summary>
		public async Task<User?> LoginAsync(string userId, string password)
		{
			if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
				return null;

			var user = await _userRepository.AuthenticateAsync(userId, password);
			return user; // 認証成功なら null ではない
		}
	}
}
