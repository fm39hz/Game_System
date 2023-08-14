using GameSystem.Component.Object.Compositor;
using Godot;
using System.Collections.Generic;
using System.Linq;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public partial class StateMachine : Node
{
	[Signal] public delegate void StateEnteredEventHandler();

	[Signal] public delegate void StateExitedEventHandler();

	[Export] public State CurrentState { get; protected set; }
	public State PreviousState { get; protected set; }
	public List<State> States { get; protected set; }
	protected bool IsInitialized { get; set; }

	public override void _Ready()
	{
		var _id = 0;
		States = new List<State>();
		foreach (var _target in GetChildren().OfType<State>())
		{
			States.Add(_target);
			_target.Id = _id++;
		}

		Init();
	}

	protected void Init()
	{
		IsInitialized = true;
		StateExited += GetOwner<ObjectCompositor>().Transition;
		StateEntered += GetOwner<ObjectCompositor>().Transition;
		foreach (var _selected in States)
		{
			StateEntered += _selected.EnteredMachine;
			_selected.StateRunning += CheckingCondition;
			StateExited += _selected.ExitMachine;
		}

		SelectState();
		PreviousState = CurrentState;
	}

	protected void SelectState()
	{
		if (!IsInitialized)
		{
			return;
		}

		foreach (var _selected in States)
		{
			if (_selected.Condition)
			{
				CurrentState = _selected;
				EmitSignal(SignalName.StateEntered);
				return;
			}
		}
	}

	protected void CheckingCondition()
	{
		if (!IsInitialized || CurrentState.Condition)
		{
			return;
		}

		PreviousState = CurrentState;
		EmitSignal(SignalName.StateExited);
		SelectState();
	}
}