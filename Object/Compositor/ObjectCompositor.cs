using GameSystem.Data.Instance;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Animation;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Object.Compositor;

[GlobalClass]
public abstract partial class ObjectCompositor : Node2D
{
	[Export] public Node Composition { get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;
	public StateMachine StateMachine { get; protected set; }
	public SpriteSheet SpriteSheet { get; protected set; }
	public ObjectData Information { get; protected set; } = new();

	public override void _Ready()
	{
		StateMachine = this.GetFirstChild<StateMachine>();
		SpriteSheet = Composition.GetFirstChild<SpriteSheet>();
		InformationInit();
		Information.Direction.IsFourDirection = IsFourDirection;
		YSortEnabled = true;
	}

	protected virtual void InformationInit()
	{
		Information = new();
	}

	public override void _PhysicsProcess(double delta)
	{
		InformationUpdate();
		PlayAnimation();
	}

	protected void PlayAnimation()
	{
		SpriteSheet.Animate(Information);
	}

	protected virtual void InformationUpdate()
	{
		Information.Update(StateMachine.CurrentState);
	}
}