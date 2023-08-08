using System;
using Godot;
using GameSystem.Component.Object;
using GameSystem.Data.Instance;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public partial class State : Node
{
	[Signal]
	public delegate void StateRunningEventHandler();

	[Export] public int ID { get; set; }
	[ExportCategory("Animation")] [Export] public int NumberOfFrame { get; protected set; }
	[Export] public bool IsLoop { get; protected set; }
	[Export] public float AnimationSpeed { get; protected set; }
	[Export] public int TransitionFrame { get; set; }
	public BaseObject Object { get; protected set; }
	public FrameData Frame { get; protected set; }
	public bool Condition { get; protected set; }
	protected StateMachine StateController { get; set; }
	protected bool IsInitialized { get; set; }

	public override void _EnterTree()
	{
		try
		{
			StateController = GetParent<StateMachine>();
			Object = GetOwner<BaseObject>();
			Frame = new FrameData(NumberOfFrame, AnimationSpeed, TransitionFrame);
			if (AnimationSpeed == 0)
			{
				IsLoop = false;
				GD.Print("Animation Loop đã được set về false vì AnimationSpeed chưa được set");
			}
		}
		catch (NullReferenceException)
		{
			GD.Print("Failed to detect State Machine for State \"" + Name + "\"");
			GD.Print("This State's Parent is \"" + GetParent().GetType() + "\"");
		}
	}

	public override void _Ready()
	{
		Init();
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateCondition(delta);
		if (StateController.CurrentState == this)
		{
			RunningState(delta);
		}
	}

	protected void Init()
	{
		IsInitialized = true;
	}

	public DynamicState ToDynamic()
	{
		return this as DynamicState;
	}

	public StaticState ToStatic()
	{
		return this as StaticState;
	}

	public bool IsState(State state)
	{
		if (state == this)
		{
			return true;
		}

		return false;
	}

	public bool IsState(string stateName)
	{
		if (stateName == Name)
		{
			return true;
		}

		return false;
	}

	public virtual void SetCondition(bool condition)
	{
		if (!IsInitialized)
		{
			return;
		}

		Condition = condition;
	}

	public virtual void ResetCondition()
	{
		if (!IsInitialized)
		{
			return;
		}

		Condition = false;
	}

	public virtual void EnteredMachine()
	{
		if (!IsInitialized)
		{
			return;
		}
	}

	public virtual void UpdateCondition(double delta)
	{
		if (!IsInitialized)
		{
			return;
		}
	}

	public virtual void RunningState(double delta)
	{
		if (!IsInitialized)
		{
			return;
		}

		EmitSignal(SignalName.StateRunning);
	}

	public virtual void ExitState()
	{
		if (!IsInitialized)
		{
			return;
		}
	}
}