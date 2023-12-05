using Godot;

namespace GameSystem.Data.Global;

public class GlobalStatus
{
	private GlobalStatus()
	{
		Instance ??= this;
		IsDebugging = false;
		MainLoop = Engine.GetMainLoop() as SceneTree;
	}

	private static GlobalStatus Instance { get; set; } = new();
	private bool IsDebugging { get; set; }
	private SceneTree MainLoop { get; }

	public static bool Debugging()
	{
		return Instance.IsDebugging;
	}

	public static double GetResponseTime()
	{
		return Engine.GetFramesPerSecond() * Instance.MainLoop.Root.GetPhysicsProcessDeltaTime();
	}

	public static void ToggleDebugMode()
	{
		Instance.IsDebugging = !Instance.IsDebugging;
	}
}