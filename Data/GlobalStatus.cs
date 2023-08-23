using Godot;

namespace GameSystem.Data.Global;

public static class GlobalStatus {
	public static double GetResponseTime(this Node target) {
		return Performance.GetMonitor(Performance.Monitor.TimeFps) * target.GetPhysicsProcessDeltaTime();
		// #if DEBUG
		// GD.Print(" Fps percentage: " + RelativeResponseTime / 100 + "%");
		// #endif
	}
}