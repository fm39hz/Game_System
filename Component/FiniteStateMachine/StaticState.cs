using GameSystem.Component.FiniteStateMachine;
using Godot;

namespace GameSystem.Core.Component.FiniteStateMachine;

[GlobalClass]
public partial class StaticState : State, IMachinaryState
{
	[ExportCategory("Motion")] [Export] public float MaxSpeed { get; protected set; }
	[Export] public float Acceleration { get; protected set; }
	[Export] public float Friction { get; protected set; }

	public void EnteredMachine()
	{
		//TODO: set up state machine
	}

	public void ExitMachine()
	{
		//TODO: clean up state machine
	}
}