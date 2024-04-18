using GameSystem.Core.Component.Animation;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Data;
using Godot;

namespace GameSystem.Core.Object.Root;

public partial class Root<TData, TBody> : Node2D where TData : ObjectData where TBody : Node
{
	[Export] public Node PhysicsBody { private get; set; }
	[Export] public ObjectData Infor { private get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;

	public TBody Body
	{
		get { return PhysicsBody as TBody; }
		set { PhysicsBody = value!; }
	}

	public TData Information
	{
		get { return Infor as TData; }
		protected set { Infor = value!; }
	}

	public StateMachine StateMachine { get; set; }
	public SpriteSheet SpriteSheet { get; set; }
}