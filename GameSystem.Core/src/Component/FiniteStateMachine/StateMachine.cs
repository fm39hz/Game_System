using Godot;

namespace GameSystem.Core.Component.FiniteStateMachine;

public abstract partial class StateMachine : Node, IStateMachine
{
	[Signal] public delegate void StateEnteredEventHandler();

	[Signal] public delegate void StateExitedEventHandler();

	[Export] public State? InitializedState { get; set; }

	public State? CurrentState { get; protected set; }
	public State? PreviousState { get; protected set; }
	public List<State> States { get; } = new();

	public abstract void Init();

	public abstract void SelectState();

	public abstract void CheckingCondition();
}