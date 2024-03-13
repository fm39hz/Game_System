using GameSystem.Core.Component.FiniteStateMachine.Base;
using Godot;

namespace GameSystem.Service.Component.FiniteStateMachine;

[GlobalClass]
public abstract partial class StaticState : BaseState
{
	[ExportCategory("Motion")] [Export] public float MaxSpeed { get; protected set; }
	[Export] public float Acceleration { get; protected set; }
	[Export] public float Friction { get; protected set; }
}