using Godot;

namespace GameSystem.Data.Global;

public class GlobalStatus
{
	public static GlobalStatus Instance { get; private set; } = new();
	private bool IsDebugging { get; set; }
	private SceneTree MainLoop { get; set; }

	private GlobalStatus()
	{
		Instance = this;
		IsDebugging = false;
		MainLoop = Engine.GetMainLoop() as SceneTree;
	}
	public static bool GetDebugInfo()
	{
		return Instance.IsDebugging;
	}
	public static double GetResponseTime()
	{
		var _delta = Instance.MainLoop.Root.GetPhysicsProcessDeltaTime();
		return Performance.GetMonitor(Performance.Monitor.TimeFps) * _delta;
	}
	public static void ToggleDebugMode()
	{
		Instance.IsDebugging = !Instance.IsDebugging;
	}
}