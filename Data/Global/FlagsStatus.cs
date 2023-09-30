using System.Collections.Generic;

namespace GameSystem.Data.Global;

public class FlagsStatus
{
	public static FlagsStatus Instance { get; private set; } = new();
	private Dictionary<string, bool> Flags { get; set; }

	private FlagsStatus()
	{
		Instance = this;
		Flags = new();
	}
	public static void AddFlag(string name, bool flag)
	{
		Instance.Flags.Add(name, flag);
	}
	public static bool GetFlag(string name)
	{
		return Instance.Flags.GetValueOrDefault(name);
	}
	public static void SetFlag(string name, bool flag)
	{
		if (Instance.Flags.ContainsKey(name))
		{
			Instance.Flags[name] = flag;
		}
	}
}