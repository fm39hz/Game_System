using Godot;
using System.Collections.Generic;
using System.Linq;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public partial class StateMachine : Node {
	[Signal]
	public delegate void StateEnteredEventHandler();

	[Signal]
	public delegate void StateExitedEventHandler();

	[Export] public State CurrentState { get; protected set; }
	public State PreviousState { get; protected set; }
	public List<State> States { get; protected set; }

	public override void _Ready() {
		var _id = 0;
		States = new List<State>();
		foreach (var _target in GetChildren().OfType<State>()) {
			States.Add(_target);
			_target.Id = _id++;
		}

		Init();
	}

	protected void Init() {
		foreach (var _selected in States) {
			StateEntered += _selected.EnteredMachine;
			_selected.StateRunning += CheckingCondition;
			StateExited += _selected.ExitMachine;
		}

		SelectState();
		PreviousState = CurrentState;
	}

	protected void SelectState() {
		foreach (var _selected in States.Where(selected => selected.Condition)) {
			CurrentState = _selected;
			EmitSignal(SignalName.StateEntered);
			return;
		}
	}

	protected void CheckingCondition() {
		PreviousState = CurrentState;
		if (CurrentState.Condition) {
			return;
		}

		EmitSignal(SignalName.StateExited);
		SelectState();
	}
}