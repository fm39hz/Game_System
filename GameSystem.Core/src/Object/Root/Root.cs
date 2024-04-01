using GameSystem.Core.Component.Animation;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Data;
using Godot;

namespace GameSystem.Core.Object.Root;

public abstract partial class Root<TData, TBody> : Node2D where TData : ObjectData where TBody : Node
{
	[Export] public required Node PhysicsBody { private get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;

	protected TBody? Body
	{
		get { return PhysicsBody as TBody; }
		set { PhysicsBody = value!; }
	}

	protected StateMachine? StateMachine { get; set; }
	protected SpriteSheet? SpriteSheet { get; set; }
	public TData? Information { get; protected set; }
}