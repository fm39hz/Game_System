using GameSystem.Component.FiniteStateMachine;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Abstraction.AbstractClass;

public abstract class BaseObjectData : IBaseObjectData
{
	public State? CurrentState { get; set; }
	public DirectionData? Direction { get; set; }
	public Vector2 Location { get; set; }
}