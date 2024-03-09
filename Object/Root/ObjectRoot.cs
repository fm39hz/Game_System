using GameSystem.Abstraction;
using GameSystem.Component.Animation;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Data.Instance;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Object.Root;

[GlobalClass]
public abstract partial class ObjectRoot : Node2D
{
	[Export] public Node PhysicsBody { get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;
	public StateMachine StateMachine { get; protected set; }
	public SpriteSheet SpriteSheet { get; protected set; }
	public IBaseObjectData Information { get; protected set; }

	public override void _Ready()
	{
		YSortEnabled = true;
		StateMachine = this.GetFirstChild<StateMachine>();
		SpriteSheet = PhysicsBody.GetFirstChild<SpriteSheet>();
		InformationInit();
		Information.Direction.IsFourDirection = IsFourDirection;
	}

	protected virtual void InformationInit()
	{
		Information = new ObjectData();
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
		Information.CurrentState = StateMachine.CurrentState;
		if (PhysicsBody is not Node2D _node) return;
		Information.Location = Position + _node.Position;
	}
}