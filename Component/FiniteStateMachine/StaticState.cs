using Godot;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public partial class StaticState : State
{
	[ExportCategory("Motion")] [Export] public float MaxSpeed { get; protected set; }
	[Export] public float Acceleration { get; protected set; }
	[Export] public float Friction { get; protected set; }
}