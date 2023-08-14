using GameSystem.Component.FiniteStateMachine;
using GameSystem.Data.Instance;

namespace GameSystem.BaseClass;

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
	/// Condition allow Compositor to Move
	/// </summary>
	public bool IsMoveable { get; set; } = true;
	/// <summary>
	/// Condition to transition Compositor Data
	/// </summary>
	public bool IsTransitioning { get; set; }

	public virtual void Update(State currentState)
	{
		CurrentState = currentState;
	}
}