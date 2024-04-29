using GameSystem.Component.FiniteStateMachine;
using Godot;

namespace GameSystem.Data;

public abstract partial class ObjectData : Resource
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