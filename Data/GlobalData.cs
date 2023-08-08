using Godot;

namespace GameSystem.Data.Global;

public partial class GlobalData : Node
{
	/// <summary>
	/// Percentage of the real fps to the ideal fps
	/// </summary>
	/// <returns>1 when fps under ideal condition</returns>
	public double RelativeResponseTime { get; private set; }

	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
	}

	public override void _PhysicsProcess(double delta)
	{
		RelativeResponseTime = Performance.GetMonitor(Performance.Monitor.TimeFps) * delta;
		GD.Print("Fps percentage: " + RelativeResponseTime / 100 + "%");
	}
}