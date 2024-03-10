using GameSystem.Component.FiniteStateMachine;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Abstraction;

public interface IBaseObjectData
{
	/// <summary>
	///     Owner current state
	/// </summary>
	public State? CurrentState { get; set; }

	/// <summary>
	///     Owner direction facing
	/// </summary>
	public DirectionData? Direction { get; set; }

	/// <summary>
	///     Owner Location
	/// </summary>
	public Vector2 Location { get; set; }
}