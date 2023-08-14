using GameSystem.BaseClass;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Animation;
using GameSystem.Utility;
using Godot;

namespace GameSystem.Component.Object.Compositor;

[GlobalClass]
public abstract partial class ObjectCompositor : Node2D
{
	[Export] public Node Target { get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;
	public StateMachine StateMachine { get; protected set; }
	public SpriteSheet SpriteSheet { get; protected set; }
	public ObjectData Information { get; protected set; } = new();
	
	public override void _Ready()
	{
		StateMachine = GodotNodeInteractive.GetFirstChildOfType<StateMachine>(Target);
		SpriteSheet = GodotNodeInteractive.GetFirstChildOfType<SpriteSheet>(Target);
		InformationInit();
		Information.Direction.IsFourDirection = IsFourDirection;
	}

	public virtual void InformationInit()
	{
		Information = new();
	}
	public override void _PhysicsProcess(double delta)
	{
		UpdateInformation();
		PlayAnimation();
	}

	protected void PlayAnimation()
	{
		SpriteSheet.Animate(Information);
	}

	protected virtual void UpdateInformation()
	{
		Information.Update(StateMachine.CurrentState);
	}
	public virtual void Transition()
	{
		Information.IsTransitioning = !Information.IsTransitioning;
		#if DEBUG
			GD.Print(Name + " is Transition");
		#endif
	}
}