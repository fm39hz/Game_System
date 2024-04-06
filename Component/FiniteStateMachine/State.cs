using GameSystem.Core.Data.Concrete;
using GameSystem.Core.Object.Root;
using Godot;

namespace GameSystem.Core.Component.FiniteStateMachine;

public partial class State : Node, IState
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
	protected ObjectRoot<ObjectData, Node2D> Root { get; set; }
	public FrameData Frame { get; protected set; }
	public bool Condition { get; set; }
	protected StateMachine StateMachine { get; set; }

	public virtual void UpdateCondition(double delta)
	{
		// TODO: implement this method
	}

	public virtual void RunningState(double delta)
	{
		EmitSignal(SignalName.StateRunning);
	}

	public override void _EnterTree()
	{
		if (AnimationSpeed == 0)
		{
			IsLoop = false;
			GD.Print("SpriteSheet Loop has been set to false because of Animation Speed is not set");
		}

		StateMachine = GetParent<StateMachine>();
		Root = GetOwner<ObjectRoot<ObjectData, Node2D>>();
		Frame = new FrameData(NumberOfFrame, AnimationSpeed, TransitionFrame);
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateCondition(delta);
		if (StateMachine!.CurrentState == this)
		{
			RunningState(delta);
		}
	}
}