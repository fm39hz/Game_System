using Godot;
using GameSystem.Component.FiniteStateMachine;

namespace GameSystem.Data.Instance;

public class ObjectData
{
	/// <summary>
	/// Owner current state
	/// </summary>
	public State CurrentState { get; set; }

	/// <summary>
	/// Owner direction facing
	/// </summary>
	public DirectionData Direction { get; set; } = new();
	
	/// <summary>
	/// Owner Location
	/// </summary>
	public Vector2 Location { get; set; } = new();
}