using GameSystem.Component.FiniteStateMachine;
using GameSystem.Data.Instance;

namespace GameSystem.BaseClass;

public class ObjectData {
	/// <summary>
	/// Owner current state
	/// </summary>
	public State CurrentState { get; set; }

	/// <summary>
	/// Owner direction facing
	/// </summary>
	public DirectionData Direction { get; set; } = new();

	public virtual void Update(State currentState) {
		CurrentState = currentState;
	}
}