using GameSystem.Data.Global;

namespace GameSystem.Utils.Save.Groups;

public static class Flags
{
	private const string GROUP_NAME = "Flags";

	public static void SetItem(string key, bool value)
	{
		var _item = DataStorage.GetGroup(GROUP_NAME);
		if (!_item.TryAdd(key, value))
		{
			_item[key] = value;
		}
		DataStorage.SetGroup(GROUP_NAME, _item);
	}

	public static bool GetItem(string key)
	{
		DataStorage.GetGroup(GROUP_NAME).TryGetValue(key, out var _value);
		return _value;
	}
}