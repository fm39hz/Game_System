using GameSystem.Data.Global;

namespace GameSystem.Utils.Save.Groups;

public static class Flags
{
	private const string GroupName = "Flags";

	public static void SetItem(string key, bool value)
	{
		var _item = DataStorage.GetGroup(GroupName);
		if (!_item.TryAdd(key, value))
		{
			_item[key] = value;
		}
		DataStorage.SetGroup(GroupName, _item);
	}

	public static bool GetItem(string key)
	{
		DataStorage.GetGroup(GroupName).TryGetValue(key, out var _value);
		return _value;
	}
}