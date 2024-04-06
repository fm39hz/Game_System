using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GameSystem.Core.Component.FiniteStateMachine;

public partial class StateMachine : Node, IStateMachine
{
	[Signal] public delegate void StateEnteredEventHandler();

	[Signal] public delegate void StateExitedEventHandler();

	[Export] public State? InitializedState { get; set; }

	public State CurrentState { get; protected set; }
	public State PreviousState { get; protected set; }
	public List<State> States { get; } = [];
	public override void _Ready()
	{
		foreach (var _target in GetChildren().OfType<State>())
		{
			States.Add(_target);
		}
		Init();
	}
	public virtual void Init()
	{
		foreach (var _selected in States)
		{
			StateEntered += _selected.EnteredMachine;
			_selected.StateRunning += CheckingCondition;
			StateExited += _selected.ExitMachine;
		}
		SelectState();
		CurrentState = InitializedState!;
		PreviousState = CurrentState;
	}
	public virtual void SelectState()
	{
		foreach (var _selected in States.Where(selected => selected.Condition))
		{
			CurrentState = _selected;
			EmitSignal(SignalName.StateEntered);
			return;
		}
	}
	public virtual void CheckingCondition()
	{
		if (CurrentState!.Condition) return;
		PreviousState = CurrentState;
		EmitSignal(SignalName.StateExited);
		SelectState();
	}
}