using GameSystem.Core.Component.FiniteStateMachine;
using Godot;

namespace GameSystem.Core.Data;

public abstract class ObjectData
{
	/// <summary>
	///     Owner current state
	/// </summary>
	public State CurrentState { get; set; }

	/// <summary>
	///     Owner direction facing
	/// </summary>
	public DirectionalData Direction { get; set; }

	/// <summary>
	///     Owner Location
	/// </summary>
	public Vector2 Location { get; set; }
}