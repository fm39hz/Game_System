using GameSystem.Core.Component.FiniteStateMachine.Interface;
using Godot;

namespace GameSystem.Core.Component.FiniteStateMachine.Base;

public abstract partial class BaseStateMachine : Node, IStateMachine
{
	[Signal] public delegate void StateEnteredEventHandler();

	[Signal] public delegate void StateExitedEventHandler();

	[Export] public BaseState? InitializedState { get; set; }

	public BaseState? CurrentState { get; protected set; }
	public BaseState? PreviousState { get; protected set; }
	public List<BaseState> States { get; } = new();

	public abstract void Init();

	public abstract void SelectState();

	public abstract void CheckingCondition();
}