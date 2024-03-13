using GameSystem.Core.Component.FiniteStateMachine.Base;
using Godot;

namespace GameSystem.Core.Data.Base;

public abstract class BaseObjectData
{
	/// <summary>
	///     Owner current state
	/// </summary>
	public BaseState? CurrentState { get; set; }

	/// <summary>
	///     Owner direction facing
	/// </summary>
	public BaseDirectionalData? Direction { get; set; }

	/// <summary>
	///     Owner Location
	/// </summary>
	public Vector2 Location { get; set; }
}