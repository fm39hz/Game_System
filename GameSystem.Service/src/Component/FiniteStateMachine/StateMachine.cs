using GameSystem.Core.Component.FiniteStateMachine.Base;
using Godot;

namespace GameSystem.Service.Component.FiniteStateMachine;

[GlobalClass]
public sealed partial class StateMachine : BaseStateMachine
{
	public override void _Ready()
	{
		foreach (var _target in GetChildren().OfType<BaseState>())
		{
			States.Add(_target);
		}
		Init();
	}

	public override void Init()
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

	public override void SelectState()
	{
		foreach (var _selected in States.Where(selected => selected.Condition))
		{
			CurrentState = _selected;
			EmitSignal(BaseStateMachine.SignalName.StateEntered);
			return;
		}
	}

	public override void CheckingCondition()
	{
		if (CurrentState!.Condition) return;
		PreviousState = CurrentState;
		EmitSignal(BaseStateMachine.SignalName.StateExited);
		SelectState();
	}
}