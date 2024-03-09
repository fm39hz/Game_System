using GameSystem.Utils.Save;

namespace GameSystem.Data.Global;

public class DataStorage
{
	private DataStorage()
	{
		Instance ??= this;
	}

	public static DataStorage Instance { get; private set; } = new();
	private Dictionary<string, Dictionary<string, dynamic>> Groups { get; set; } = new();

	private static void AddGroup(string group)
	{
		Instance.Groups.TryAdd(group, new());
	}

	public static Dictionary<string, dynamic> GetGroup(string group)
	{
		if (!Instance.Groups.ContainsKey(group))
		{
			AddGroup(group);
		}
		return Instance.Groups[group];
	}

	public static void SetGroup(string group, Dictionary<string, dynamic> item)
	{
		if (!Instance.Groups.ContainsKey(group))
		{
			AddGroup(group);
		}
		Instance.Groups[group] = item;
	}

	public static void Save()
	{
		SaveFileHandling.Save(Instance.Groups);
	}

	public static void Load()
	{
		Instance.Groups = SaveFileHandling.Load();
	}
}