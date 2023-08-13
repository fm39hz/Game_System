using GameSystem.Component.Object.Compositor;
using Godot;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public partial class DynamicState : State
{
	[ExportCategory("Motion")] [Export] public float MaxSpeed { get; protected set; }
	[Export] public float Acceleration { get; protected set; }
	[Export] public float Friction { get; protected set; }
	private ObjectCompositor Compositor { get; set; }
}