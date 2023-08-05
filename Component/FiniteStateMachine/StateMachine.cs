using GameSystem.Component.Object.Directional;
using Godot;
using System.Collections.Generic;
using System.Linq;

namespace GameSystem.Component.FiniteStateMachine;
	[GlobalClass]
	public partial class StateMachine : Node{
		[Signal] public delegate void StateEnteredEventHandler();
		[Signal] public delegate void StateExitedEventHandler();
		[Export] public State CurrentState { get; protected set; }
		public State PreviousState { get; protected set; }
		public List<State> States { get; protected set; }
		protected bool IsInitialized { get; set; }
		public override void _Ready(){
			var _id = 0;
			States = new();
			foreach (var target in GetChildren().OfType<State>()){
				States.Add(target);
				target.ID = _id++;
				}
			Init();
			}
		protected void Init(){
			IsInitialized = true;
			StateExited += GetParent<DynamicObject>().Transition;
			StateEntered += GetParent<DynamicObject>().Transition;
				foreach (var selected in States){
					StateEntered += selected.EnteredMachine;
					selected.StateRunning += CheckingCondition;
					StateExited += selected.ExitState;
					}
			SelectState();
			PreviousState = CurrentState;
			}
		protected void SelectState(){
			if (!IsInitialized){
				return;
				}
			foreach (var selected in States){
				if (selected.Condition){
					CurrentState = selected;
					EmitSignal(SignalName.StateEntered);
					return;
					}
				}
			}
		protected void CheckingCondition(){
			if (IsInitialized && !CurrentState.Condition){
				PreviousState = CurrentState;
					EmitSignal(SignalName.StateExited);
					SelectState();
				}
			}
		}
