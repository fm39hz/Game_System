using System;
using System.Linq;
using GameSystem.Data.Instance;
using GameSystem.Object.Root;
using Godot;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public abstract partial class State : Node
{
	[Signal]
	public delegate void StateRunningEventHandler();

	[Export] public int Id { get; set; }

	[ExportCategory("SpriteSheetPlayer")]
	[Export]
	public int NumberOfFrame { get; protected set; }

	[Export] public bool IsLoop { get; protected set; }
	[Export] public float AnimationSpeed { get; protected set; }
	[Export] public int TransitionFrame { get; set; }
	protected ObjectRoot Root { get; set; }
	public FrameData Frame { get; protected set; }
	public bool Condition { get; protected set; }
	protected StateMachine StateMachine { get; set; }

	public override void _EnterTree()
	{
		try
		{
			if (AnimationSpeed == 0)
			{
				IsLoop = false;
				GD.Print("SpriteSheet Loop has been set to false because of Animation Speed is not set");
			}

			StateMachine = GetParent<StateMachine>();
			Root = GetOwner<ObjectRoot>();
			Frame = new FrameData(NumberOfFrame, AnimationSpeed, TransitionFrame);
		}
		catch (NullReferenceException)
		{
			GD.Print("Failed to detect State Machine for State \"" + Name + "\"");
			GD.Print("This State's Parent is \"" + GetParent().GetType() + "\"");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateCondition(delta);
		if (StateMachine.CurrentState == this)
		{
			RunningState(delta);
		}
	}

	public virtual void SetCondition(bool condition)
	{
		Condition = condition;
	}

	public virtual void ResetCondition()
	{
		Condition = false;
	}

	public virtual void EnteredMachine()
	{
		#if DEBUG
		GD.Print("Entered " + Name + " state");
		#endif
	}

	protected virtual void UpdateCondition(double delta)
	{
		#if DEBUG
		GD.Print("Updated " + Name + " state");
		#endif
	}

	protected virtual void RunningState(double delta)
	{
		#if DEBUG
		GD.Print("Running " + Name + " state");
		#endif
		EmitSignal(SignalName.StateRunning);
	}

	public virtual void ExitMachine()
	{
		#if DEBUG
		GD.Print("Exited " + Name + " state");
		#endif
	}
}