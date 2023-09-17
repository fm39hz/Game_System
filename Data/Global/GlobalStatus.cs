namespace GameSystem.Data.Global;

public class GlobalStatus
{
	public static bool IsDebug { get; private set; }
	public static GlobalStatus Instance { get; private set; } = new();

	private GlobalStatus()
	{
		IsDebug = false;
		Instance = this;
	}

	public static void ToggleDebugMode()
	{
		IsDebug = !IsDebug;
	}
}