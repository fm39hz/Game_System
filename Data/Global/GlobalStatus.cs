namespace GameSystem.Data.Global;

public class GlobalStatus
{
	public bool IsDebug { get; private set; }
	public static GlobalStatus Instance { get; private set; } = new();
	private GlobalStatus()
	{
		IsDebug = false;
		Instance = this;
	}

	public void ToggleDebugMode()
	{
		IsDebug = !IsDebug;
	}
}