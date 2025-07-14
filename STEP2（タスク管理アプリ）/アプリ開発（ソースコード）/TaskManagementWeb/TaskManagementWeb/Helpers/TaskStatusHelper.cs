namespace TaskManagementWeb.Helpers
{
	public static class TaskStatusHelper
	{
		private static readonly Dictionary<int, string> _statusMap = new()
		{
			{ 0, "完了" },
			{ 1, "着手中" },
			{ 2, "未着手" }
		};

		public static string GetStatusName(int statusValue)
		{
			return _statusMap.TryGetValue(statusValue, out var name) ? name : "不明";
		}

		public static IReadOnlyDictionary<int, string> StatusMap => _statusMap;
	}
}
